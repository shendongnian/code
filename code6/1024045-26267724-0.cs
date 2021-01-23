    public class Mapper
    {
        private const BindingFlags DestConstructorFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
        private const BindingFlags DestFlags = BindingFlags.Instance | BindingFlags.Public;
        private const BindingFlags SrcFlags = BindingFlags.Instance | BindingFlags.Public;
        private static readonly object[] NoArgs = new object[0];
        private static readonly Type GenericEmbeddedSourceType = typeof(HalResource<>);
        private readonly Dictionary<Type, Func<object, object>> _oneWayMap = new Dictionary<Type, Func<object, object>>();
        public void CreateMap<TDestination, TSource>() 
            where TDestination : class 
            where TSource : HalResource
        {
            CreateMap(typeof(TDestination), typeof(TSource));
        }
        public void CreateMap(Type destType, Type srcType)
        {
            _oneWayMap[srcType] = InternalCreateMapper(destType, srcType);
        }
        public object Map<TSource>(TSource toMap) where TSource : HalResource
        {
            var mapper = default(Func<object, object>);
            if (!_oneWayMap.TryGetValue(typeof(TSource), out mapper))
                throw new KeyNotFoundException(string.Format("No mapping for {0} is defined.", typeof(TSource)));
            return mapper(toMap);
        }
        public TDestination Map<TDestination, TSource>(TSource toMap)
            where TDestination : class
            where TSource : HalResource
        {
            var converted = Map(toMap);
            if (converted != null && !typeof(TDestination).IsAssignableFrom(converted.GetType()))
                throw new InvalidOperationException(string.Format("No mapping from type {0} to type {1} has been configured.", typeof(TSource), typeof(TDestination)));
            return (TDestination)converted;
        }
        public void Clear()
        {
            _oneWayMap.Clear();
        }
        private static Func<object, object> InternalCreateMapper(Type destType, Type srcType)
        {
            // Destination specific constructor + setter map.
            var destConstructor = BuildConstructor(destType.GetConstructor(DestConstructorFlags, null, Type.EmptyTypes, null));
            var destSetters = destType
                .GetProperties(DestFlags)
                .Where(p => p.CanWrite)
                .ToDictionary(k => k.Name, v => Tuple.Create(v.PropertyType, BuildSetter(v)));
            // Source specific getter maps
            var srcPrimPropGetters = CreateGetters(srcType);
            var srcEmbeddedGetter = default(Func<object, object>);
            var srcEmbeddedPropGetters = default(IDictionary<string, Tuple<Type, Func<object, object>>>);
            var baseType = srcType.BaseType;
            while (baseType != null && baseType != typeof(object))
            {
                if (baseType.IsGenericType && GenericEmbeddedSourceType.IsAssignableFrom(baseType.GetGenericTypeDefinition()))
                {
                    var genericParamType = baseType.GetGenericArguments()[0];
                    if (srcPrimPropGetters.Any(g => g.Value.Item1.Equals(genericParamType)))
                    {
                        var entry = srcPrimPropGetters.First(g => g.Value.Item1.Equals(genericParamType));
                        srcPrimPropGetters.Remove(entry.Key);
                        srcEmbeddedGetter = entry.Value.Item2;
                        srcEmbeddedPropGetters = CreateGetters(entry.Value.Item1);
                        break;
                    }
                }
                baseType = baseType.BaseType;
            }
            // Build mapper delegate function.
            return (src) =>
            {
                var result = destConstructor(NoArgs);
                var srcEmbedded = srcEmbeddedGetter != null ? srcEmbeddedGetter(src) : null;
                foreach (var setter in destSetters)
                {
                    var getter = default(Tuple<Type, Func<object, object>>);
                    if (srcPrimPropGetters.TryGetValue(setter.Key, out getter) && setter.Value.Item1.IsAssignableFrom(getter.Item1))
                        setter.Value.Item2(result, getter.Item2(src));
                    else if (srcEmbeddedPropGetters.TryGetValue(setter.Key, out getter) && setter.Value.Item1.IsAssignableFrom(getter.Item1))
                        setter.Value.Item2(result, getter.Item2(srcEmbedded));
                }
                return result;
            };
        }
        private static IDictionary<string, Tuple<Type, Func<object, object>>> CreateGetters(Type srcType)
        {
            return srcType
                .GetProperties(SrcFlags)
                .Where(p => p.CanRead)
                .ToDictionary(k => k.Name, v => Tuple.Create(v.PropertyType, BuildGetter(v)));
        }
        private static Func<object[], object> BuildConstructor(ConstructorInfo constructorInfo)
        {
            var param = Expression.Parameter(typeof(object[]), "args");
            var argsExp = constructorInfo.GetParameters()
                .Select((p, i) => Expression.Convert(Expression.ArrayIndex(param, Expression.Constant(i)), p.ParameterType))
                .ToArray();
            return Expression.Lambda<Func<object[], object>>(Expression.New(constructorInfo, argsExp), param).Compile();
        }
        private static Func<object, object> BuildGetter(PropertyInfo propertyInfo)
        {
            var instance = Expression.Parameter(typeof(object), "instance");
            var instanceCast = propertyInfo.DeclaringType.IsValueType
                ? Expression.Convert(instance, propertyInfo.DeclaringType)
                : Expression.TypeAs(instance, propertyInfo.DeclaringType);
            var propertyCast = Expression.TypeAs(Expression.Property(instanceCast, propertyInfo), typeof(object));
            return Expression.Lambda<Func<object, object>>(propertyCast, instance).Compile();
        }
        private static Action<object, object> BuildSetter(PropertyInfo propertyInfo)
        {
            var setMethodInfo = propertyInfo.GetSetMethod(true);
            var instance = Expression.Parameter(typeof(object), "instance");
            var value = Expression.Parameter(typeof(object), "value");
            var instanceCast = propertyInfo.DeclaringType.IsValueType
                ? Expression.Convert(instance, propertyInfo.DeclaringType)
                : Expression.TypeAs(instance, propertyInfo.DeclaringType);
            var call = Expression.Call(instanceCast, setMethodInfo, Expression.Convert(value, propertyInfo.PropertyType));
            return Expression.Lambda<Action<object, object>>(call, instance, value).Compile();
        }
    }

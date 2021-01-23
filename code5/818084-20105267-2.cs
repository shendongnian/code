    // Type aliases used for brevity
    using Accessor = System.Func<object, object>;
    using E = System.Linq.Expressions.Expression;
    internal static class AttributeHelpers
    {
        private const BindingFlags DeclaredFlags = BindingFlags.Instance |
                                                   BindingFlags.Public |
                                                   BindingFlags.NonPublic |
                                                   BindingFlags.DeclaredOnly;
        private const BindingFlags InheritedFlags = BindingFlags.Instance |
                                                    BindingFlags.Public |
                                                    BindingFlags.NonPublic;
        private static readonly Accessor NullCallback = _ => null;
        [ThreadStatic]
        private static Dictionary<Type, Dictionary<Type, Accessor>> _cache;
        private static Dictionary<Type, Accessor> GetCache<TAttribute>()
            where TAttribute : Attribute
        {
            if (_cache == null)
                _cache = new Dictionary<Type, Dictionary<Type, Accessor>>();
            Dictionary<Type, Accessor> cache;
            if (_cache.TryGetValue(typeof(TAttribute), out cache))
                return cache;
            cache = new Dictionary<Type, Accessor>();
            _cache[typeof(TAttribute)] = cache;
            return cache;
        }
        public static object MemberWithAttribute<TAttribute>(this object target)
            where TAttribute : Attribute
        {
            if (target == null)
                return null;
            var accessor = GetAccessor<TAttribute>(target.GetType());
            if (accessor != null)
                return accessor(target);
            return null;
        }
        private static Accessor GetAccessor<TAttribute>(Type targetType)
            where TAttribute : Attribute
        {
            Accessor accessor;
            var cache = GetCache<TAttribute>();
            if (cache.TryGetValue(targetType, out accessor))
                return accessor;
            var member = FindMember<TAttribute>(targetType);
            if (member == null)
            {
                cache[targetType] = NullCallback;
                return NullCallback;
            }
            var targetParameter = E.Parameter(typeof(object), "target");
            var accessorExpression = E.Lambda<Accessor>(
                E.Convert(
                    E.MakeMemberAccess(
                        E.Convert(targetParameter, targetType),
                        member),
                    typeof(object)),
                targetParameter);
            accessor = accessorExpression.Compile();
            cache[targetType] = accessor;
            return accessor;
        }
        private static MemberInfo FindMember<TAttribute>(Type targetType)
            where TAttribute : Attribute
        {
            foreach (var property in targetType.GetProperties(DeclaredFlags))
            {
                var attribute = property.GetCustomAttribute<TAttribute>();
                if (attribute != null)
                    return property;
            }
            foreach (var field in targetType.GetFields(DeclaredFlags))
            {
                var attribute = field.GetCustomAttribute<TAttribute>();
                if (attribute != null)
                    return field;
            }
            foreach (var property in targetType.GetProperties(InheritedFlags))
            {
                var attribute = property.GetCustomAttribute<TAttribute>();
                if (attribute != null)
                    return property;
            }
            foreach (var field in targetType.GetFields(InheritedFlags))
            {
                var attribute = field.GetCustomAttribute<TAttribute>();
                if (attribute != null)
                    return field;
            }
            return null;
        }
    }

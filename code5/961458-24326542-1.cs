        private static void MapFields<T>(T target, T source)
        {
            Type type = typeof (T);
            if (!Mappers.ContainsKey(type))
            {
                //build expression to copy fields from source to target;
                var targetParam = Expression.Parameter(typeof(object));
                var targetCasted = Expression.TypeAs(targetParam, typeof(T));
                var sourceParam = Expression.Parameter(typeof(object));
                var sourceCasted = Expression.TypeAs(sourceParam, typeof(T));
                var setters = new List<Expression>();
                //get all non-readonly fields
                foreach (var fieldInfo in typeof(T).GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public).Where(f => !f.IsInitOnly))
                {
                    Expression targetField = Expression.Field(targetCasted, fieldInfo);
                    Expression sourceField = Expression.Field(sourceCasted, fieldInfo);
                    setters.Add(Expression.Assign(targetField, sourceField));
                }
                Expression block = Expression.Block(setters);
                var mapperFunction = Expression.Lambda<Action<object, object>>(block, targetParam,
                    sourceParam).Compile();
                Mappers[type] = mapperFunction;
            }
            Mappers[type](target, source);
        }
        private static readonly Dictionary<Type, Action<object, object>> Mappers =
            new Dictionary<Type, Action<object, object>>();

        public static List<object> ListGroupKeys<TEntity>(this IQueryable<TEntity> source, string fieldName)
            where TEntity : class, IDataEntity
        {
            var results = source.GroupBy(fieldName, "it").Select("new (KEY as Group)");
            var list = new List<object>();
            foreach (var result in results)
            {
                var type = result.GetType();
                var prop = type.GetProperty("Group");
                list.Add(prop.GetValue(result));
            }
            return list;
        }

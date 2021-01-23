        public static IEnumerable<T> GetRecords<T>(this IEnumerable<T> source)
        {
            //check property exists
            var temp = Activator.CreateInstance(typeof(T), new object[] { });
            if (temp.GetType().GetProperty("valid") == null)
                return source;
            return (from item in source
                    let table = item.GetType()
                    let property = table.GetProperty("valid")
                    let value = property.GetValue(item, null)
                    where (int)value == 1
                    select item).ToList();
        }

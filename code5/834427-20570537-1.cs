        public static IList<T> MyMethod<T>(IList<T> myList, string filter)
        {
            if (myList == null) return null;
            if (filter == null) return myList;
            var tfilter = filter.GetType();
            var properties = typeof(T).GetProperties().Where(x => x.PropertyType.FullName == typeof(string).FullName);
            if (!properties.Any()) return null;
            var res = new List<T>();
            foreach(var el in myList)
            {
                foreach(var p in properties)
                {
                    if ((string)p.GetValue(el) == filter)
                    {
                        res.Add(el);
                        break;
                    }
                }
            }
            return res;
        }

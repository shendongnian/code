         private static List<T> GetAsList<T>(string value) 
            {
                List<T> list = new List<T>();
                var items = value.Split('|');
                foreach (var item in items)
                {
                    TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));
                    if (converter != null)
                    {
                        list.Add((T)converter.ConvertFrom(item));
                    }
                }
                return list;
            }

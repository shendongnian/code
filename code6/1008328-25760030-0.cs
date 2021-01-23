    public T MapObjects<T, Y>(Y item)
            {
                T _item = Activator.CreateInstance<T>();
    
                foreach (PropertyInfo propertyInfo in typeof(Y).GetProperties())
                {
    
                    if (typeof(T).GetProperty(propertyInfo.Name, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public) != null)
                        typeof(T).GetProperty(propertyInfo.Name, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public).SetValue(_item, propValue);
                }
    
                return _item;
            }

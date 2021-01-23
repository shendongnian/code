    static void FillCodesFromId<T, S>(T input, S unused = default(S))
            where T : new()
            where S : new()
        {
            Type type = typeof(T);
            foreach (var item in type.GetProperties())
            {
                Type tempType = item.PropertyType;
                if (tempType is IEnumerable<S>)
                {
                    IEnumerable<S> list = item.GetValue(input) as IEnumerable<S>;
                    foreach (var listItem in list)
                    {
                        FillCodesFromId(listItem, default(S)); 
                    }
                }
            }
        }

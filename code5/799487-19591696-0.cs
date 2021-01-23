    static T Temp<T>(params object[] obj) where T:ICollection, new ()
        {
            T s = new T();
            //TODO: validation for input values
            if (s is IDictionary)
            {
                ((IDictionary) s).Add(obj[0], obj[1]);
            }
            else if (s is IList)
            {
                ((IList)s).Add(obj[0]);
            }
            return s;
        }

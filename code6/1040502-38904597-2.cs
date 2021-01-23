    /// <summary>
    /// Given two models, return TRUE if all the properties are equal,
    /// else return FALSE
    /// </summary>
    /// <typeparam name="TModel">Type of the models being compared</typeparam>
    public class PropertyEqualityComparer<TModel> : IEqualityComparer<TModel>
    {
        public bool Equals(TModel x, TModel y)
        {
            PropertyInfo[] props = typeof(TModel).GetProperties();
            foreach (PropertyInfo prop in props)
            {
                if (!Object.Equals(prop.GetValue(x), prop.GetValue(y)))
                {
                    return false;
                }    
            }
            return true;
        }
        public int GetHashCode(TModel obj)
        {
            int hash = 1;
            PropertyInfo[] props = typeof(TModel).GetProperties();
            foreach (PropertyInfo prop in props)
            {
                hash ^= prop.GetValue(obj).GetHashCode();
            }
            return hash;
        }
    }

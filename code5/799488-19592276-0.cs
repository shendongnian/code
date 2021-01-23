        public static void AddToCollection(this ICollection col, object value)
        {
            if (col is IDictionary)
            {
                ((IDictionary)col).Add(value, value);
            }
            else if(col is IList)
            {
                ((IList)col).Add(value);
            }
        }

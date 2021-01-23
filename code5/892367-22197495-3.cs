    public class CustomDataRowComparer : IEqualityComparer<DataRow>
    {
        public bool Equals(DataRow x, DataRow y)
        {
            if (x.ItemArray.Length != y.ItemArray.Length)
                return false;
            for (int i = 0; i < x.ItemArray.Length; i++)                            
                if (!x[i].Equals(y[i]))
                    return false;            
            return true;
        }
        public int GetHashCode(DataRow obj)
        {
            int hash = 17;
            foreach (object field in obj.ItemArray)
                hash = hash * 19 + field.GetHashCode();
            return hash;
        }
    }

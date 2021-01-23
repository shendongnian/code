    public class DataRowValueComparer : IEqualityComparer<object[]>
    {
        public bool Equals(object[] x, object[] y)
        {
            // didn't test but this probably doesn't work if one of the datacolumns is a Byte[]
            return x.SequenceEqual(y);
        }
        public int GetHashCode(object[] obj)
        {
            // You will want better hashcode 
            //  can look at https://stackoverflow.com/a/3404820/1798889 for more info
            return obj.Length.GetHashCode();
        }
    }

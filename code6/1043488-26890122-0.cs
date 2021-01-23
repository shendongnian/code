    var myData = gridData.AsEnumerable()
                         .GroupBy(r => r, new MyDataComparer(keys))
                         .ToList();
    
    internal class MyDataComparer : IEqualityComparer<MyDataType>
    {
        private readonly string[] _keys;
    
        public MyDataComparer(string[] keys)
        {
            _keys = keys; // keep the keys to compare by.
        }
    
        public bool Equals(MyDataType x, MyDataType y)
        {
            // a simple implementation that checks if all the required fields 
            // match. This might need more work.
            bool areEqual = true;
            foreach (var key in _keys)
            {
                areEqual &= (x[key].Equals(y[key]));
            }
            return areEqual;
        }
    
        public int GetHashCode(DataRow obj)
        {
            // Add implementation here to create an aggregate hashcode.
        }
    }    

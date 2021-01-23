    public class RowComparer : IComparer<string>
    {
        private int _columnIndex;
    
        public RowComparer(int columnIndex)
        {
            _columnIndex = columnIndex;
    
        }
        public int Compare(string a, string b)
        {
            string valA = a.Split(',')[columnIndex];
            string valB = b.Split(',')[columnIndex];
            if(valA == valB) return 0;
    
            return valA >  valB ? 1 : -1;
            
        }
    }

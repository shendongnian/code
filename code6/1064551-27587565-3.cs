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
    List<string> rows = GetAllLinesFromFile();
    // sort ascending by column index 2 (Value)
    rows = rows.OrderBy(r=> r, new RowComparer(2));
    
    // sort descending by column index 1 (Name)
    rows = rows.OrderByDescending(r=> r, new RowComparer(1));

    public class TableParameter
    {
        public string sEcho { get; set; }
        public int iDisplayStart { get; set; }
        public int iDisplayLength { get; set; }
        public int iSortingCols { get; set; } 
        public int iSortCol_0 { get; set; } // the first (and usually only) column to be sorted by
        public string sSortDir_0 { get; set; } // the direction of the first column sort (asc/desc)
        public int iSortCol_1 { get; set; } // the second column to be sorted by
        public string sSortDir_1 { get; set; } // the direction of the second column sort
        // etc
    }

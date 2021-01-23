    private class CustomComparer : IComparer
    {
        private static int SortOrder = 1;
    
        public CustomComparer(SortOrder sortOrder)
        {
            SortOrder = sortOrder == SortOrder.Ascending ? 1 : -1; 
        }
    
        public int Compare(object x, object y)
        {
            DataGridViewRow row1 = (DataGridViewRow)x;
            DataGridViewRow row2 = (DataGridViewRow)y;
    
            int result = row1.Cells["EmpName"].Value.ToString().CompareTo(
                                        row2.Cells["EmpName"].Value.ToString());
    
            if ( result == 0 )
            {
                result = DateTime.ParseExact(
                             row1.Cells["InTime"].Value.ToString(),
                             "h:mm tt",
                             CultureInfo.InvariantCulture).TimeOfDay
                       .CompareTo(
                         DateTime.ParseExact(
                             row2.Cells["InTime"].Value.ToString(),
                             "h:mm tt",
                             CultureInfo.InvariantCulture).TimeOfDay);
            }
            return result * SortOrder;
        }

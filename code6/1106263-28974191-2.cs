     private void DGV_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
     {
       string s1 = e.CellValue1.ToString().Substring(0, 6) + 
                   e.CellValue1.ToString().Substring(6).PadLeft(3, '0');
       string s2 = e.CellValue2.ToString().Substring(0, 6) + 
                   e.CellValue2.ToString().Substring(6).PadLeft(3, '0');
       e.SortResult = s1.CompareTo(s2);
       e.Handled = true;
     }

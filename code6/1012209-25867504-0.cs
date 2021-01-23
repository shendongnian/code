    public static class CTableManager
    {
        public static DataTable Select(DataTable dt, string sFilter)
        {
            DataTable dtResult = dt.Clone();
            try
            {
                dtResult = dt.Select(sFilter).CopyToDataTable();
            }
            catch { }
            return dtResult;
        }
        public static DataTable Sort(DataTable dt, string sOrder)
        {
             DataTable dtResult = dt.Clone();
             try
             {
                 dt.DefaultView.Sort = sOrder;
                 dtResult = dt.DefaultView.ToTable().Copy();
             }
             catch { }
             return dtResult;
        }
         public static DataTable SelectAndSort(DataTable dt, string sFilter, string sOrder)
        {
            DataTable dtResult = dt.Copy();
            if (sFilter != string.Empty)
            {
                dtResult = Select(dtResult, sFilter);
            }
            if (sOrder != string.Empty)
            {
                dtResult = Sort(dtResult, sOrder);
            }
            return dtResult;
        }
    }

     public DataTable  SelectTopDataRow(DataTable dt, int count)
    {
     DataTable dtn = dt.Clone();
     for (int i = 0; i < count; i++)
     {
         dtn.ImportRow(dt.Rows[i]);
     }
     return dtn;
    }

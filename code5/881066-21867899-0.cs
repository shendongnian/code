       StringBuilder strb = new StringBuilder();
       DataColumn[] dca = new DataColumn[ds.Tables[0].Columns.Count];
       ds.Tables[0].Columns.CopyTo(dca, 0);
       string format = "['{0}'],\n";
       strb.AppendFormat(format, string.Join("','", dca.Select(c => c.ColumnName)));
       foreach (DataRow dr in ds.Tables[0].Rows)
          strb.AppendFormat (format, string.Join ("','", dr.ItemArray.Select (i => i.ToString ())));

    using (System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection
    ("Provider=Microsoft.Jet.OLEDB.4.0;Extended Properties='text;HDR=Yes;FMT=Delimited';Data Source=" + HttpContext.Current.Server.MapPath("/System/SaleList/"))
            {
               string sql_select = "select * from [" + this.FileName + "]";
               System.Data.OleDb.OleDbDataAdapter da = new System.Data.OleDb.OleDbDataAdapter();
               da.SelectCommand = new System.Data.OleDb.OleDbCommand(sql_select, conn);
               DataSet ds = new DataSet();
   
               // Read the First line of File to know the header
               string[] lines = System.IO.File.ReadAllLines(HttpContext.Current.Server.MapPath("/System/SaleList/") + FileName);
            DataTable mdt=new DataTable("ListData");
            for (int i = 1; i < lines.Length; i++)
			{
			 string[] sep=lines[i].Split(',');
                foreach (var item in sep)
	           {
                   mdt.Rows.Add(sep);
	           }
			}
               string header = "";
               if (lines.Length > 0)
                  header = lines[0];
               string[] headers = header.Split(',');
            ds.Tables.Add(mdt);
            CreateSchema(headers, FileName);
            da.Fill(ds, "ListData");
           DataTable dt = mdt;}

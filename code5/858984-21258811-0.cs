    static void Main(string[] args)
    {
        DataTable dt = GetTable();
        DataRow[] dr = dt.Select("Date= MAX(Date)");
       if (dr!=null)
       {
          Console.WriteLine(dr[0]["Date"]);
       }    
    }
    
    static DataTable GetTable()
    {
        DataTable table = new DataTable();
        table.Columns.Add("ID", typeof(int));
        table.Columns.Add("Date", typeof(string));
    
        table.Rows.Add(1, DateTime.Now.AddDays(1).ToString());
        table.Rows.Add(2, DateTime.Now.AddDays(-1).ToString());
        table.Rows.Add(3, DateTime.Now.AddDays(-2).ToString());
        table.Rows.Add(4, DateTime.Now.AddDays(3).ToString());
    
        return table;
    }

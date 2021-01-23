    void Main()
    {
        string expT = "IIF(b1=true,1,0) + IIF(b2=true,1,0) + IIF(b3=true,1,0)";
        string expF = "IIF(b1=false,1,0) + IIF(b2=false,1,0) + IIF(b3=false,1,0)";
        
        DataTable dt = new DataTable();
        dt.Columns.Add("Description", typeof(string));
        dt.Columns.Add("b1", typeof(Boolean));
        dt.Columns.Add("b2", typeof(Boolean));
        dt.Columns.Add("b3", typeof(Boolean));
        dt.Columns.Add("CountF", typeof(int), expF);
        dt.Columns.Add("CountT", typeof(int), expT);
    
    
        DataRow r = dt.NewRow();
        r.ItemArray = new object[] {"Desc1", true, true, false};
        dt.Rows.Add(r);
        r = dt.NewRow();
        r.ItemArray = new object[] {"Desc2", false, true, false};
        dt.Rows.Add(r);
        r = dt.NewRow();
        r.ItemArray = new object[] {"Desc3", true, false, true};
        dt.Rows.Add(r);
        r = dt.NewRow();
        r.ItemArray = new object[] {"Desc4", false, false, false};
        dt.Rows.Add(r);
    }

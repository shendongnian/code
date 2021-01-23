      DataTable dt = new DataTable();           
      dt.Columns.Add("X", typeof(int));
      dt.Columns.Add("Y", typeof(int));
      dt.Columns.Add("R", typeof(int), "X/Y");
      dt.Columns.Add("", typeof(double), "R*3000.00");
      dt.Columns.Add("test", typeof(double), "(1/3)*3000.00");
      DataRow r = dt.NewRow();
      r["X"] = 1;
      r["Y"] = 3;
      dt.Rows.Add(r);
      int i = (int)dt.Rows[0]["R"];     //return 0
      double d = (double)dt.Rows[0][3]; //return 0.0
      double d1 = (double)dt.Rows[0]["test"]; //return 1000.0

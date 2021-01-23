    public DataTable showout()
    {
      DataTable dtab = new DataTable();
      // More efficient way of adding the columns with types:
      dtab.Columns.Add("رقم المتسلسل", typeof(String));
      dtab.Columns.Add("رقم الحساب", typeof(String));
      dtab.Columns.Add("أسم الحساب", typeof(String));
      /*
      DataColumn dc1 = new DataColumn("رقم المتسلسل");
      DataColumn dc2 = new DataColumn("رقم الحساب");
      DataColumn dc3 = new DataColumn("أسم الحساب");
      dtab.Columns.Add(dc1);
      dtab.Columns.Add(dc2);
      dtab.Columns.Add(dc3);
      */
      // Create a new row using the .NewRow method
      DataRow datRow = dtab.NewRow();
      datRow["رقم المتسلسل"] = numb.Text;
      datRow["رقم الحساب"] = textBox5.Text;
      datRow["أسم الحساب"] = note.Text;
      // Add the new row to the DataTable
      dtab.Rows.Add(datRow);
     return dtab;
    }

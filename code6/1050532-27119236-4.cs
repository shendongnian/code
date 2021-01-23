    DataTable dt = new DataTable();
    dt.Columns.AddRange(new DataColumn[3] { new DataColumn("Id"), new DataColumn("Name") });
    dt.Rows.Add(1, "Pam);
    dt.Rows.Add(2, "Richard");
    dt.Rows.Add(3, "Mary");
    tblAgenda.DataSource = dt;
    tblAgenda.DataBind();

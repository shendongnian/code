    GridView1.AutoGenerateColumns = false;
    GridView1.Columns.Add(new BoundField() { HeaderText = "ID", DataField = "ID" });
    GridView1.Columns.Add(new BoundField() { HeaderText = "Dep Name", DataField = "Dep_Name" });
    GridView1.Columns.Add(new BoundField() { HeaderText = "Sales Profit", DataField = "Sales_Profit" });
    GridView1.Columns.Add(new BoundField() { HeaderText = "Sales Transport", DataField = "Sales_Transport" });
    GridView1.DataBind();

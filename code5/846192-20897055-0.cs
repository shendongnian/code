    radGridView1.Columns.Add(new GridViewTextBoxColumn("age"));
    radGridView1.Columns.Add(new GridViewTextBoxColumn("iq"));
    radGridView1.Columns.Add(new GridViewDecimalColumn("total"));
    radGridView1.Rows.Add("5", "5");
    radGridView1.Columns["total"].Expression = "age - iq";

    DataTable table = new DataTable();
    //put some data in your table and then
    table.Columns.Add("C1");
    table.Columns.Add("C2");
    String[] examplerow = new String[] {"one","two"};
    table.Rows.Add(examplerow);
    DataRow row = table.Rows[0];
    Console.WriteLine(row["C1"]); // Or pass it to textboxes, etc

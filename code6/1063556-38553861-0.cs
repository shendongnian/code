    var contents = new DataTable();
    using (OleDbDataAdapter adapter = new OleDbDataAdapter(string.Format("Select * From [{0}$]", TabDisplayName), conn))
    {
        adapter.Fill(contents);
    }
    Console.WriteLine(contents.Rows.Count);//7938

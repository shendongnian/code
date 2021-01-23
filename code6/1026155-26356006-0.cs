    string connectionString = @"Server=PC\SQLEXPRESS;Database=AsposeTest;User ID=a;Password=a";
    SqlConnection conn = new SqlConnection(connectionString);
    conn.Open();
    string sql = "SELECT * FROM MyTable";
    SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
    DataSet ds = new DataSet();
    adapter.Fill(ds, "MyTable");
    // Load Word document
    Aspose.Words.Document doc = new Aspose.Words.Document(dataDir + "Orders_Template.docx");
    doc.MailMerge.ExecuteWithRegions(ds);
    doc.Save(dataDir + "Orders.docx");
    Process.Start(dataDir + "Orders.docx");
    conn.Close();

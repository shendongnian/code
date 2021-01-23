    System.IO.StreamReader file = new System.IO.StreamReader("yourfile.txt");
    string[] columnnames = file.ReadLine().Split(' ');
    DataTable dt = new DataTable();
    foreach (string c in columnnames)
    {
        dt.Columns.Add(c);
    }
    string newline;
    while ((newline = file.ReadLine()) != null)
    {
        DataRow dr = dt.NewRow();
        string[] values = newline.Split(' ');
        for (int i = 0; i < values.Length; i++)
        {
            dr[i] = values[i];
        }
        dt.Rows.Add(dr);
    }
    file.Close();
    dataGridView1.DataSource = dt;

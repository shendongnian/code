    void Insert_Record(object s, EventArgs e)
    {
        string dbconnection = "Provider=Microsoft.ACE.OLEDB.12.0;" + @"data source =BookCSharp.accdb";
        string dbcommand = "SELECT * FROM Books;";
        using(OleDbConnection conn = new OleDbConnection(dbconnection))
        using(OleDbCommand comm = new OleDbCommand(dbcommand, conn))
        {
             OleDbDataAdapter adapter = new OleDbDataAdapter(comm);
             OleDbCommandBuilder builder = new OleDbCommandBuilder(adapter);
             conn.Open();            
             adapter.Fill(ds, "Books");
             DataTable dt = ds.Tables[0];
             DataRow newRow   = dt. NewRow();
             newRow["BookKey"] = txtBookKey.Text;
             newRow["Title"]  = txtTitle.Text;
             newRow["Pages"]  = txtPages.Text;
             dt.Rows.Add(newRow);
             builder.GetInsertCommand();
             adapter.Update(ds, "Books");
        }
        //update listBox1
        lstDisplayBooks.Items.Clear();
        foreach (DataRow row in ds.Tables[0].Rows)
        {
            lstDisplayBooks.Items.Add(row["BookKey"] + " " + row["Title"] + " (" + row["Pages"] + ")");
        }
        txtBookKey.Enabled = false;
        txtBookKey.Text = " ";
        txtTitle.Enabled = false;
        txtTitle.Text = " ";
        txtPages.Enabled = false;
        txtPages.Text = " ";
        btnInsert.Enabled = false;
    }

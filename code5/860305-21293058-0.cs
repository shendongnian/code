    private void button1_Click(object sender, EventArgs e)
    {
        using OleDbConnection mycon = new OleDbConnection()
        {
            mycon.ConnectionString =@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Dinesh\C#\GIS_Power\WindowsFormsApplication1\bin\Power_DB1.accdb";
            OleDbCommand command = new OleDbCommand();
            command.CommandText = "INSERT INTO Table1 (Emp_ID, Asset_ID, Date_Column) VALUES ('?', '?', '?')";
            command.Parameters.Add("@EmpID", OleDbType.VarChar, 80).Value = textBox1.Text;
            command.Parameters.Add("@AssetID", OleDbType.VarChar, 80).Value = textBox2.Text;
            command.Parameters.Add("@Timestamp", OleDbType.DBTimeStamp).Value = DateTime.Now;
            
            command.Connection = mycon;
            mycon.Open();
            command.ExecuteNonQuery();
        }
    }

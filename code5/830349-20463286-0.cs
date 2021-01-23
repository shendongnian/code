        int anInteger = Convert.ToInt32(textBox7.Text);        
        sConnection = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=hospital database.accdb";
        dbConn = new OleDbConnection(sConnection);
        dbConn.Open();
        sql = "SELECT * FROM Patients where PatientID=@PatientID";
        dbCmd = new OleDbCommand();
        dbCmd.CommandText = sql;
        dbCmd.Parameters.AddWithValue("@PatientID",anInteger);
        dbCmd.Connection = dbConn;
        dbReader = dbCmd.ExecuteReader();
        listBox1.Items.Clear();
        while (dbReader.Read())
        {
           //now display the reader values here : sample
           //TextBox1.Text=dbReader["name"].ToString();
        }
        

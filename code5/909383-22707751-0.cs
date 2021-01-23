    private void button1_Click(object sender, EventArgs e)
    {
        System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection();
        conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
        @"Data source= C:\Users\user\Documents\Visual Studio 2010\Projects\WindowsFormsApplication1\WindowsFormsApplication1\crt_db.accdb";
        conn.Open();
    
        String my_querry = @"INSERT INTO System (Name, Address, Conperson, Scope_of_certification, Certification, Date_issued,
                            Dateofsurv, Dateofrecerti, Remark, certi_fee)
                     VALUES (@name, @address, @conPerson, @scope, @cert, @dateIssued, ...");
    
        OleDbCommand cmd = new OleDbCommand(my_querry, conn);
        cmd.Parameters.AddWithValue("@name", txtName.Text);
        cmd.Parameters.AddWithValue("@address", txtAddress.Text);
        ...
        cmd.Parameters.AddWithValue("@dateIssued", dateTimePicker1.Value);
        ...
        cmd.ExecuteNonQuery();
        conn.Close();
    }

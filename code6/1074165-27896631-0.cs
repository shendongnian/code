    SqlCommand cmd;
    try {
        conn.Open();
        string query = "INSERT INTO Customers (col1, col2, col3,...) VALUES ('val1', 'val2', 'val3',...)";
        cmd = new SqlCommand(query, conn);
        int RowsAffected = cmd.ExecuteNonQuery();
        if(RowsAffected > 0) {
        //If you are on Console:
        Console.WriteLine("1 Row Inserted");
    
        //If you are on WinForms / WebForms:
        lblMessage.Text = "1 Row Inserted";
    } catch (Exception ex) {
        //If you are on Console:
        Console.WriteLine("Some Exception: " + ex.Message.ToString());
    
        //If you are on WinForms / WebForms:
        lblMessage.Text = "Some Exception: " + ex.Message.ToString();
    } finally {
        conn.Close();
    }

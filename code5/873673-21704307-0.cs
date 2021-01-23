    validateDept.InitializeConnection();
    OleDbConnection con = new OleDbConnection(validateDept.connetionString);
    con.Open();
    OleDbCommand delete1 = new OleDbCommand("delete from NewInvoice_1 where InvoiceNumber=" +        temp, con); 
    OleDbCommand delete2 = new OleDbCommand("delete from NewInvoice_2 where InvoiceNumber=" + temp, con);
    delete1 .ExecuteNonQuery();
    delete2 .ExecuteNonQuery();
    con.Close();

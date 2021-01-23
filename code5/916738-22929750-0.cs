    DateTime curdate = DateTime.Now;
    curdate = curdate.AddDays(-30); // if i give -4 instead of -30 the query will bind data
    DateTime curdate1 = DateTime.Now;
    
    validateDept.InitializeConnection();
    OleDbConnection connection = new OleDbConnection(validateDept.connetionString);
    OleDbDataAdapter adapter = new OleDbDataAdapter(
          "SELECT InvoiceId, InvoiceNumber, InvoiceDate, (Select CustomerId from Customer
          Where Customer.CustomerId=NewInvoice_1.CustomerName) AS CustomerId, (Select
          CustomerName from Customer where Customer.CustomerId = NewInvoice_1.CustomerName)
          AS CustomerName, DueDate, Tax, GrandTotal, CompanyId FROM NewInvoice_1 WHERE
          InvoiceDate >= #" + curdate.ToString("dd/MMM/yyyy") + "# AND InvoiceDate <= #" +         
          curdate1.ToString("dd/MMM/yyyy") + "# ", connection);
    DataSet sourceDataSet = new DataSet();
    adapter.Fill(sourceDataSet);
    gridControl1.DataSource = sourceDataSet.Tables[0];

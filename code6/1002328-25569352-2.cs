    public string DisplayWarning(int invoiceID)
    {
        string sql = @"Select DATEDIFF(day,Date,Getdate()) as DiffDate 
                       From Invoice 
                       WHERE InvoiceID=@InvoiceID";
        using(var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RechnungConnectionString"].ConnectionString))
        using (var datecmd = new SqlCommand(sql, conn))
        {
            datecmd.Parameters.Add(new SqlParameter("@InvoiceID", SqlDbType.Int)).Value = invoiceID;
            // Here you don't need a loop since you only get one row back
            // ...
        }
    }

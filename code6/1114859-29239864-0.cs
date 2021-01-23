    using (SqlConnection cs = new SqlConnection("Data Source=JAMES-DESKTOP\\SQLEXPRESS;Initial Catalog=contacts;Integrated Security=True"))
    using (SqlCommand cmd = new SqlCommand("dbo.LookupInvoices", cs))
    {
        cmd.CommandType = CommandType.StoredProcedure;
    
        int cboItemNumber = cmbInvoiceNumbers.SelectedIndex;
        int invNumber = Convert.ToInt32(cmbInvoiceNumbers.Items[cboItemNumber].ToString());
    
        cmd.Parameters.Add("@invoiceNumber", SqlDbType.Int).Value = invNumber;
    
        cs.Open();
    
        using (SqlDataReader reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
               .........
            }
        }
    
        cs.Close();
    }

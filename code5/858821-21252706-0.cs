    using(var con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:/Srihari/Srihari/Invoice.accdb"))
    using(var cmd = new OleDbCommand("SELECT MAX(InvoiceNumber) from NewInvoice_1", con))
    {
        con.Open();
        int max = 0;
        object objMax = cmd.ExecuteScalar();
        if(objMax != null) max = (int) objMax;
        int newMax = max++; // insert this into the database instead of the string "INV001"
        // you can use newMax.ToString("000") or ToString("D3") or ToString().PadLeft(3, '0')
        string newNumber = string.Format("INV{0}", newMax.ToString().PadLeft(3, '0'));
        // ...
    }

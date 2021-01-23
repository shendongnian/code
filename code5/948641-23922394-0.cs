    for (var i = 1; i <= 20; i++)
    {    
        if (!String.IsNullOrEmpty(Controls.Find("txtProductID" + i, true).Single().Text))
        {
            using (var oledbconnection1 = new OleDbConnection())
            {
                oledbconnection1.ConnectionString = Con;
                oledbconnection1.Open();
                var insertStatement =
                    "Insert into [InvoiceOrder] Values ('1', @InvoiceNo, @ProductDesc, @OrderNo, @Unit, @Amount, @Price, @Sum, @Discount)";
                try
                {
                    using (var cmd = new OleDbCommand(insertStatement, oledbconnection1))
                    {
                        cmd.Parameters.AddWithValue("@InvoiceNo", Controls.Find("txtInvoiceNo" + i, true).Single().Text);
                        ...
                        ...
                        cmd.Parameters.AddWithValue("@Discount", Controls.Find("txtDiscount" + i, true).Single().Text);
                        cmd.ExecuteNonQuery();
                        //MessageBox.Show("Record saved");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error : " + ex.ToString());
                }
            }
        }
    }

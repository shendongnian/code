    string sql = "UPDATE NewInvoice_1 SET Terms =?, [InvoiceDate]=?, OurQuote=? ... WHERE InvoiceId=?";
    
    			using (var command = conn.CreateCommand())
    			{
    				command.CommandText = sql;
    				command.Parameters.Add(CBL_Terms.EditValue.ToString());
    				command.Parameters.Add(CBL_Date.DateTime);
    				command.Parameters.Add(TXE_OurQuote.Text);
    			
    				//add all other fields keeping order
    					
    				command.ExecuteNonQuery();
    			}

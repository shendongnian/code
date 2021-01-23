     try
        {
            for (int i = 0; i < gvInvTransaction.Rows.Count - 1; i++)
            {
                TextBox txtproduct = (TextBox)gvInvTransaction.Rows[i].FindControl("txtProduct");
                TextBox txtBarcode = (TextBox)gvInvTransaction.Rows[i].FindControl("txtBarCode");
                TextBox txtPrdctBatchID = (TextBox)gvInvTransaction.Rows[i].FindControl("txtPrdctBatchID");
                TextBox txtPrdctID = (TextBox)gvInvTransaction.Rows[i].FindControl("txtPrdctID");
                TextBox txtStdPurchasePrice = (TextBox)gvInvTransaction.Rows[i].FindControl("txtUnitPrice");
                TextBox txtStdSalesPrice = (TextBox)gvInvTransaction.Rows[i].FindControl("txtUnitPrice");
              
           
                string  ProductID = Convert.ToInt64(txtPrdctID.Text);
                string  StdPurchasePrice = Convert.ToDouble(txtStdPurchasePrice.Text);
                string  StdSalesPrice = Convert.ToDouble(txtStdPurchasePrice.Text);
                
                 
             
                
             
            }
        }
        catch (Exception ex) { }
    }

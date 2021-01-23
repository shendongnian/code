    string query = "UPDATE dbo.[NCAProduct] ([ProductName], [SupplierCode], [Cost], [RetailPrice], [Quantity], [BestBefore]) VALUES (@txtUPProductName,@txtUPSupplierCode,@txtUPCost,@txtUPRetail,@txtUPQuantity, @date) WHERE [ProductCode] = @txtUPProdCode";
            using (SqlCommand addProduct = new SqlCommand(query, SQLcon))
            {
                addProduct.Parameters.AddWithValue("@date", SqlDbType.DateTime).Value = bestBeforeDTP.Value.Date;
                addProduct.Parameters.AddWithValue("@txtUPProductName", txtUPProductName.Text);
                addProduct.Parameters.AddWithValue("@txtUPSupplierCode", Convert.ToInt32(txtUPSupplierCode.Text));
                addProduct.Parameters.AddWithValue("@txtUPCost", Convert.ToInt32(txtUPCost.Text));
                addProduct.Parameters.AddWithValue("@txtUPRetail", Convert.ToInt32(txtUPRetail.Text));
                addProduct.Parameters.AddWithValue("@txtUPQuantity", Convert.ToInt32(txtUPQuantity.Text));
                addProduct.Parameters.AddWithValue("@txtUPProdCode", Convert.ToInt32(txtUPProdCode.Text));
                addProduct.ExecuteNonQuery();
            }

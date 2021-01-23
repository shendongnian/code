    private void txtBarcode_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (txtBarcode.Text.Length == 13)
                {
                    var product = ObjGasLogic.GetProduct(txtBarcode.Text.Trim());
                    
                    if (product != null)
                    {
                        objProductDetails = product;
                        objProductDetails.Quantity = 0;
                        BindCurrentlySelectedProduct();                                             
                    }
                    else
                    {                        
                        MessageBox.Show("Item Not Found");
                        ClearCurrentSelectedProductDetails();
                    }
                }
            }
            catch (Exception ex)
            {
                ObjExceptionLogic.LogException(ex.Message, Convert.ToInt32(User.Instance.User_ID));                
            }
        }

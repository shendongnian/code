     foreach (DataSet1.ProductRow item in pTable.Rows)
                {
                    //if the current item in the table is matching the item that is selected by the user
                    if (item.ID == Convert.ToInt32(e.CommandArgument)) 
                    {
                        //then assign values to a created instance of a cartItem (a class that I have)
                        CartItem currentItem = new CartItem();
                        currentItem.UnitPrice = item.Price;  
                    }
                }

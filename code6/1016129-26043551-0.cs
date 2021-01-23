    var ordersDB = new SQLite.SQLiteConnection(orderPath);
                        
    Orders ord = new Orders();
           
    ord.custNum = tblCustomerNumber.Text;
    ord.itemNum = tbxEnterItem.Text;
    ord.itemQty = tbxQty.Text;
    ord.itemDesc = tblOrderItemDesc.Text;
    ord.itemCost = tblOrderItemCost.Text;
    ord.orderDate = DateTime.Now.ToString();
             
    ordersDB.BeginTransaction();
    ordersDB.Insert(ord);
    ordersDB.Commit();
    ordersDB.Dispose();
    ordersDB.Close();

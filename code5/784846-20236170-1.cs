    `public ActionResult SelectCustomerByID(Receipt model, string secondValue)
            {
                //Receipt Recepit = new Receipt();
                int CustID = 0;
                if (secondValue != "")
                CustID = Convert.ToInt32(secondValue);
                    ObservableCollection<Receipt> ReceiptList = new ObservableCollection<Receipt>();
                    Receipt Receipt = new Models.Receipt();
                if(CustID!=0)
                    ReceiptList = Receipt.GetReceiptListByCustID(CustID);
                else
                    ReceiptList = Receipt.GetReceiptList();
    
                    ViewData["Count"] = ReceiptList.Count;
                    return PartialView("_Recepitgrid", ReceiptList);
                
                           
            }

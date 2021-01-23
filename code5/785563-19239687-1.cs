Controller
    public ActionResult SelectCustomerByID(Receipt model, string secondValue)
    {
     int CustID = 0;
     if (secondValue != "")
     CustID = Convert.ToInt32(secondValue);
     ObservableCollection<Receipt> ReceiptList = new ObservableCollection<Receipt>();
     Receipt Receipt = new Models.Receipt();
     ReceiptList = Receipt.GetReceiptListByCustID(CustID);
     return PartialView("_Recepitgrid", ReceiptList);
    }

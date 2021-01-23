    //TO Insert
    [HttpPost]
            public ActionResult ReceiptMaster(Receipt model, string command)
            {
                Receipt Receipt = new Models.Receipt();
    
                if (command == "Sumbit")
                {
                    int Id = 0;
                    if (model.Pay_Mode == "C")
                    {
                        model.ChequeNo = "";
                        model.Cheque_Date = ("1/1/1753 12:00:00 AM");
                        model.Bank_Name = "";
                        model.Bank_Address = "";
                    }
    
                    if (ModelState.IsValid)
                    {
                        Id = Receipt.SaveReceipt(model.Id, model.Cust_Id, model.Pay_Amount, model.Pay_Mode, model.Bank_Name, model.Bank_Address, model.ChequeNo, model.Cheque_Date);
                        if (Id > 0)
                        {
                            ViewData["Success"] = "Product was saved successfully.";
                            ViewData["ControlView"] = 1;
                              ObservableCollection<Receipt> ReceiptList = new              ObservableCollection<Receipt>();
                ReceiptList = Receipt.GetReceiptList();
                return View(ReceiptList);
    
                        }
                        ObservableCollection<Receipt> ReceiptList = new ObservableCollection<Receipt>();
                ReceiptList = Receipt.GetReceiptList();
                return View(ReceiptList);
                    }
    
                    ObservableCollection<Receipt> ReceiptList = new ObservableCollection<Receipt>();
                    ReceiptList = Receipt.GetReceiptList();
                    return View(ReceiptList);
                }
    
                ObservableCollection<Receipt> ReceiptList1 = new ObservableCollection<Receipt>();
                ReceiptList1 = Receipt.GetReceiptList();
                return View(ReceiptList1);
    
            }

    public ActionResult Details(int CustomerID)
    {
        //simplified for brevity
        //get from LGCustDatas
        LGCustData custData = dbContext.LGCustDatas.GetByCustomerID(CustomerID);
        //get from LGCustLogins model
        var custLogin = dbContext.LGCustLogins.GetByCustomerID(CustomerID);
        //You can 'combine' models via a view model
        var custDataVM = new LGCustDataViewModel();
        custDataVM.LastName = custData.LastName;
        custDataVM.FirstName = custData.FirstName;
        custDataVM.BirthDate = custData.BirthDate;
        custDataVM.UserName = custLogin.UserName;
        custDataVM.Password = custLogin.Password;
        return View(custDataVM);
    }

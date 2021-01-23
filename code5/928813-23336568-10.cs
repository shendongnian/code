    public ActionResult Index()
    {
        //simplified for brevity
        //get from LGCustDatas
        List<LGCustData> custData = dbContext.LGCustDatas.GetAllCustomers();
        var listCustomer = new List<LGCustDataViewModel>();
        foreach(customer in LGCustData)
        {
            //You can 'combine' models via a view model
    
            var custDataVM = new LGCustDataViewModel();
            custDataVM.LastName = customer.LastName;
            custDataVM.FirstName = customer.FirstName;
            custDataVM.BirthDate = customer.BirthDate;
            //get from LGCustLogins model
            var custLogin = dbContext.LGCustLogins.GetByCustomerID(customer.CustomerID);
            custDataVM.UserName = custLogin.UserName;
            custDataVM.Password = custLogin.Password;
            listCustomer.Add(custDataVM);
        }
        return View(listCustomer);
    }

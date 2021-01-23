    public ActionResult MyView()
    {
        List<LGDetail> lgDetailList = dbContext.LGCustDatas.GetAllCustomers();                  
        var viewModelObj = new LGDetailViewModel();
        viewModelObj.LGDetailList = lgDetailList;
        viewModelObj.Username = "whatever";
    }

        public ActionResult User_Read()
        {
            ViewModels.ViewModelA objView = new ViewModels.ViewModelA();
        
                oViewModelA objView = new ViewModelA()  ;
                objView.MyList = new List<SomeClass>();
                objView.MyList.Add(new SomeClass() { FirstName = "Test", Supervisor =                   "SomeValue" });
                objView.MyList.Add(new SomeClass() { FirstName = "AnotherTest", Supervisor = "SomeMore" });
        
                return Json(objView.MyList, JsonRequestBehavior.AllowGet);
        }

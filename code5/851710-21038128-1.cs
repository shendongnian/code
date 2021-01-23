    public ActionResult Index()
        {
            Test test = new Test();
            var valExit == DBCheckFunction();
            if(valExit ! = null)
            {
                test.TextBox1 = valExit.val1 ;
                test.TextBox2 = valExit.val2 ;
                test.TextBox3 = valExit.val3 ;
                test.TextBox4 = valExit.val4 ;
                return View(test);
            }
            else
            {
                return view(test);
            }
           
        }

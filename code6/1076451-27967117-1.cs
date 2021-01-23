     public ActionResult Index(string green, string yellow, string other)
            {
               //Create a Dropdown list
                var SearchOptionList = new List<string>();
                SearchOptionList.Add("Green");
                SearchOptionList.Add("Yellow");
                SearchOptionList.Add("Other");
                
     var mylist = from m in "your database name goes in here" select m;
    
    return View(mylist.ToList());
    
    }

     public ActionResult Index(string Colour)
            {
               //Create a Dropdown list
                var SearchOptionList = new List<string>();
                SearchOptionList.Add("Green");
                SearchOptionList.Add("Yellow");
                SearchOptionList.Add("Other");
                
     var mylist = from m in "your database table name goes in here" select m;
    //Clears dropdown list
     ModelState.Remove("Colour")
    return View(mylist.ToList());
    
    }

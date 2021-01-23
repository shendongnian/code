     public ActionResult SelectedDropDownResult(FormCollection fc)
            {
                int dropDown = int.Parse(fc["SelectedDropDownValue"]);
                ViewBag.dropDownValue = dropDown;
    
                List<int> key = new List<int>();
                key.Add(1); key.Add(2); key.Add(3); key.Add(4); key.Add(5);
                ViewBag.RequiredKey = new SelectList(key);
    
                return View();
            }
   

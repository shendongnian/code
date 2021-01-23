    [HttpPost]
     public ActionResult View2(NorthOrder q,int drop, string button)
     {
                  if (button == "Add")
           {
    string strDDLValue= db.Products.FirstOrDefault(_=>_.ProductID == drop).ProductName;
                           return View();
       }
    }

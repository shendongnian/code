     public ActionResult insert()
        {
            customer cus = new customer();
            int id = Convert.ToInt16(Request.Form["customerid"]);
            string code = Request.Form["customercode"].ToString();
            int amt = Convert.ToInt16(Request.Form["amount"]);
            int _records = cus.Insert(id, code, amt);
            if (_records > 0)
            {
                return RedirectToAction("Fillcustomer", "customerdetail");//change this
            }
            else
            {
                ModelState.AddModelError("", "Can Not Insert");
            }
            return View(cus);
        }

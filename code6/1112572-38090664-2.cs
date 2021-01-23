    [HttpPost]
    public ActionResult Index(List<Contact> list)
    {  
        if (ModelState.IsValid)
        {
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                foreach (var i in list)
                {
                    var c = dc.Contacts.Where(a =>a.ContactID.Equals(i.ContactID)).FirstOrDefault();
                    if (c != null)
                    {
                        c.ContactPerson = i.ContactPerson;
                        c.Contactno = i.Contactno;
                        c.EmailID = i.EmailID;
                    }
                }
                dc.SaveChanges();
            }
            ViewBag.Message = "Successfully Updated.";
            return View(list);
        }
        else
        {
            ViewBag.Message = "Failed ! Please try again.";
            return View(list);
        }
    }

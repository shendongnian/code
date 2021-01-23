    [HttpPost]
    public ActionResult Complete(FormCollection c)
    {
        int i = 0;
        if (ModelState.IsValid)
        {
            var DelIDArray = c.GetValues("item.id");
            var DelCompleteArray = c["complete"];
            
            var n = 0;
            for (i = 0; i < DelIDArray.Count(); i++)
            {
                string find = DelIDArray[i].ToString();
                 deliverylist dels = db.deliverylists.Find(Convert.ToInt32(DelIDArray[i]));
                    if (c.GetValues("complete")[n] == "false")
                    {
                        dels.is_complete = 0;
                        n = n + 1;
                    }
                    else
                    {
                        dels.is_complete = 1;
                        n = n + 2;
                    }
                    db.Entry(dels).State = EntityState.Modified;
            }
            db.SaveChanges();
        }
        return RedirectToAction("Complete");
    }

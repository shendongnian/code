    [HttpPost, ActionName("DeleteAll")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteAllConfirmed()
    {
        IEnumerable<Customer> customerList = db.Customers.Where(i => i.IsDeleted == true);
        //Now you have everything you need.
        foreach (var Item in customerList) 
        { 
            //Remove
            db.Customers.Remove(Item); 
        }
        //and save. done
        db.SaveChanges(); //important!
        return RedirectToAction("Index");
    }

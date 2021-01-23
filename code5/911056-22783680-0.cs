    [HttpPost] 
    public ActionResult Edit(int id, Model model) 
    { 
         using (var db = new YourEntities()) 
         { 
             //control that, it does not change
             model.datetime_inclusion = db.YourTable.Find(id).datetime_inclusion;
        
             db.Entry(model).State = System.Data.EntityState.Modified; 
             db.SaveChanges(); 
             return RedirectToAction("Index"); 
         } 
    }

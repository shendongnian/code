    public ActionResult Event_History(int id = 0)
    {
        //set into false the active flag of the event
        var events = db.Events_Info_tbl.Find(id);
        events.is_active = false;        
        //set the category under this event into inactive
        var category = db.Events_Category_tbl.Where(x=>x.events_info_id==id).ToList();          
        foreach(var cat in category){
            cat.is_active = false;
        }
        db.SaveChanges();
        TempData["MessageAlert"] = "Event is save in history!";
        return RedirectToAction("Index");
    }

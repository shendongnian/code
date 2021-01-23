    public ActionResult AddCompToEventClass (int compeditorid)
    {
      var model = from o in _db.Events
        join o2 in _db.Event_Classes on o.EventID equals o2.EventID
        where o.EventID.Equals(o2.EventID)
        join o3 in _db.Class_Definitions on o2.ClassID equals o3.Class_Definition_ID
        where o2.ClassID.Equals(o3.Class_Definition_ID)
        where o.CurrentEvent.Equals(true)
        select new AddCompToEventClass 
        {
          Event = o, 
          Event_Class = o2, 
          Class_Definition = o3,
          Compeditor = new Compeditor
          {
            CompeditorId = compeditorid
          }
        };
      return view(model);
    }

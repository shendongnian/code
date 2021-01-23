    public ActionResult Edit(int? id, DateTime timestamp)
    {
        var stamping = db.Stampings.Find(id, timestamp);
        //snip
    }

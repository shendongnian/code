    public ActionResult GetResponse(int id)
    {
         //some logic
         Task.Run(() => { B.Update(id); }).Wait();
         //some logic
         return View(...);
    }

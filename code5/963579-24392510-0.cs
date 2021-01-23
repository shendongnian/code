    public ActionResult Details(int id = 0)
    {
        FilterQueue filterqueue = db.FilterQueues.SingleOrDefault(f => f.FilterQueueId == id);
        if (filterqueue == null)
        {
            return HttpNotFound();
        }
        return View(filterqueue);
    }

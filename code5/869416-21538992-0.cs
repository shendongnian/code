    [HttpPost]
    public ActionResult DoIt()
    {
        var context = GlobalHost.ConnectionManager.GetHubContext<IssuesHub>();
        Thread.Sleep(3000);
        context.Clients.All.updateProgress(new { Status = "10 %" });
        Thread.Sleep(3000);
        context.Clients.All.updateProgress(new { Status = "50 %" });
        Thread.Sleep(3000);
        context.Clients.All.updateProgress(new { Status = "60 %" });
    
        return Json(new { Status = "100%" });
    }

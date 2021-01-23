    public ActionResult ShowFunction()
    {
        ThreadPool.QueueUserWorkItem(c =>
        {
            // Some long-running job
        });
        return Content("Your request is under process");
    }

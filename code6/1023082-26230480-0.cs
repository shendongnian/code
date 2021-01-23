    [DllImport("Win32Library.dll")]
    public static extern Int16 inc();
    private readonly static DateTime AppDomainStarted = DateTime.UtcNow;
    public ActionResult Counter()
    {
        return new JsonResult { Data = new { counter = inc(), appDomainId = AppDomain.CurrentDomain.Id, started = AppDomainStarted.ToString() }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
    }

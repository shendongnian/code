    public ActionResult Index()
    {
     ....
     ViewBag.MyDropDownList1 = context.someTables.Select(t=>t);
    }

    public ActionResult Index()
    {           
        var vm = new PropListVM { Props = GetPropsFromSomeWhere() };
        return View(vm);
    }
    private List<PropModel> GetPropsFromSomeWhere()
    {
        var list = new List<PropModel>();
        //Hard coded for demo. You may replace it with DB items
        list.Add(new PropModel { Name = "Detroit", Value = "123" });
        list.Add(new PropModel { Name = "Ann Arbor", Value = "345" });
        return list;
    }

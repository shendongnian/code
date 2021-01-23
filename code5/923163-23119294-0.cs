    public class MyViewModel 
    {
        public bool GetAll { get; set; }
        public SomeDataModel[] MyData { get; set; }
    }
    public ActionResult Index(bool? getAll)
    {
       SomeDataModel[] data;
       if (getAll != null && (bool) getAll)
       {
          var data = GetSomeData(true);
       }
       else
       {
          var data = GetSomeData(false);
       }
       return View(new MyViewModel() { MyData = data, GetAll = getAll == true });
    }

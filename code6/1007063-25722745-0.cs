    public class MyCustomViewModel
    {
      public TimeSpan QueryDuration { get; set;}
      public IEnumerable<SomeModelClass> Persons { get; set; }
    }
   
    public ActionResult MyActionMethod()
    { 
        var vm = new MyCustomViewModel();
    
        Stopwatch _watch = StopWatch.StartNew()
        vm.Persons = executeQueryHere().ToList();
        vm.Queryduration = _watch.Elapsed;
        return View(vm);
    } 

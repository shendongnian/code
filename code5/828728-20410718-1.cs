    public class TestController
      {
        public ActionResult Test1()
        {
          return View(CreateTestModel());
        }
    
        [HttpGet]
        public ActionResult Test2()
        {
          return View(CreateTestModel());
        }
    
        [HttpPost]
        public ActionResult Test3(TestModel model)
        {
          return View(CreateTestModel());
        }
    
        private TestModel CreateTestModel() {
          TestModel model = new TestModel();
          TestRepository rep = new TestRepository ();
          model.ReportData = rep.GetData(IdObject);
          return model
        }
    }

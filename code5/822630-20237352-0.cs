    public class MyModel{
        public string FirstName {get; set;}
        public string LastName{get; set;)
        public bool IsHappy {get; set;}
        // etc. etc
    }
    public ActionResult GetData(MyModel data)
    {
       return View();
    }

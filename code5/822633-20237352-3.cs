    public class MyModel{
        public string FirstName {get; set;}
        public string LastName{get; set;)
        public bool IsHappy {get; set;}
        // etc. etc
    }
    public ActionResult GetData(MyModel data)
    {
       // do what you need with the data here
       return View();
    }

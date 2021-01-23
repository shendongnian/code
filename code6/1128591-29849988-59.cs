    public ActionResult Index()
    {
        var register = new Register
        {
            students = new List<Person>
            {
                new Person { firstName = "", lastName = "" }
            },
            teachers = new List<Person> 
            {
                new Person { lastName = "", firstName = "" }
            }
        };
    
        return View(register);
    }

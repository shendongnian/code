    public class Person
    {
        public string Name {get;set;}
        public int Age {get;set;}
    }
    public ViewResult Index()
    {
        Person p = new Person() { Name = "P1", Age = 100};
        return View(p);//
    }

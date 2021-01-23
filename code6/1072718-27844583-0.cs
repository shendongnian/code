    Person per = new Person(); // your MVC4 App local model.
    per.Name = "Vibin";
    per.Phone = 123456789;
    FirstService.WebService service = new FirstService.WebService();
    mvcEmpty.FirstService.Person p = new mvcEmpty.FirstService.Person(); // Web service person generated during proxy generation when you add web reference.
    p.Name = per.Name;
    p.phone = per.Phone;
    service.TakeList(p);

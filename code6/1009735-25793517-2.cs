    public ActionResult Home(int page = 1, Person person)
    {
       // get the initial data - i assume that you using some context for it (you can use service as well)   
       using(var context = new DbContext())
       {
           var data = context.... //get the data here
           if(person != null)
           {
               data = data.Where(p => p.id == person.id).ToList(); //filter by id for example
           }
           //assuming your view gets a List as a model
           return View(data)
       }
    }

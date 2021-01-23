    // Controller:
    public ActionResult Index(int? id)
    {
         // Person Model:
         var model = new Person();
         
         // Call Database Method, to populate Model
         model = dbPerson.Fill(id); // dbPerson.Fill would be a method to populate.
         return View(model);
    }
    // View: (Index of our Controller)
    @if(Model != null)
    {
         foreach(var content in Model)
         {
               <div>@content.FirstName</div>
               <div>@content.LastName</div>
         }
    }

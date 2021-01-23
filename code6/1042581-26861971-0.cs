    public class Project
    {
        public int ID {get; set;}
        [DisplayName ("Project Name")]
        public string ProjectName { get; set; }
        [DisplayName("Client")]    
        public string ClientID { get; set; }
        public string Description { get; set; }
        [DisplayName("Use Cases")]
        public virtual ICollection <UseCase> UseCases { get; set; } 
    }
    
    public class Actor
    {
        public int ID { get; set; }
        public int projectID { get; set; }
        public virtual Project project { get; set; } 
        public string Title { get; set; }
    
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
    
    // GET: Actors
    public ActionResult Index(int? id)
    {
        ViewBag.projectId = id;
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        
        using (var context = new DbContext()) // initiate a connection to the DB
        {
            var actors = context.Actors.Where(x => x.projectID == id);
            // tell it to include the projects
            actors.Include("project"); // the name of the property
            
            // now retrieve list from the DB
            actors.ToList();
            // return the actors to the view
            return View(actors);
        }
     }

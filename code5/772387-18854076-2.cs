    public class ContactsController
    {
        private UnitOfWorkFactory _factory { get; set; }
        public ContactsController(UnitOfWorkFactory factory)
        {
            factory = _factory;
        }
        public ActionResult Index(int pageSize, int currentPage)
        {
             using(var db = factory.Create() enew MvcLearningContext())
             {
                 var contacts = db.Contacts
                                  .Skip((currentPage - 1) * pageSize)
                                  .Take(pageSize)
                                  .ToList();
                 return View(contacts);
             }
        }
    }

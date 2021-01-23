    public class ContactsController
    {
        public ActionResult Index(int pageSize, int currentPage)
        {
             using(var db = new MvcLearningContext())
             {
                 var contacts = db.Contacts
                                  .Skip((currentPage - 1) * pageSize)
                                  .Take(pageSize)
                                  .ToList();
                 return View(contacts);
             }
        }
    }

    public class LogController : Controller
    {
        [HttpGet]
        public ActionResult Create(int ResidentID)
        {
            // Run in debug and make sure the residentID is the right one
            // and the resident exists in the database
            var resident = database.Residents.Find(residentID);
            
            var model = new ViewModels.ResidentLog
            {
                ResidentID = resident.ResidentID,
                PFName = resident.PFName,
                PLName = resident.PLName,
                Comments = string.Empty,
                // ...
            };
            // Run in debug and make sure model is not null and of type ResidentLog
            // and has the PFName and PLName
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(ViewModels.ResidentLog model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var log = new Models.Logs 
            { 
               // Assumes LogID gets assigned by database?
               ResidentID = model.ResidentID,
               Comments = model.Comments,
            };
            // Run in debug and make sure log has all required fields to save
            database.Logs.Add(log);
            database.SaveChanges();
            return RedirectToAction("Index"); // Or anywhere you want to redirect
        }
    }

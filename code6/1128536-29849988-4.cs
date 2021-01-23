    public class CompanyEmployeeController : Controller
        {
            private MyContext db = new MyContext();
    
            // GET: CompanyEmployee
            public ActionResult Index()
            {
                var newCompanyEmployee = new CompanyEmployee();
                newCompanyEmployee.employees = db.EmployeeContext.ToList();
                return View(newCompanyEmployee);
            }
    [HttpPost, ActionName("Delete")]
            public ActionResult DeleteConfirmed(int id)
            {
                Employee employee = db.EmployeeContext.Find(id);
                db.EmployeeContext.Remove(employee);
                db.SaveChanges();
                return RedirectToAction("Index", "CompanyEmployee");
            }
    
    [HttpPost]
            public ActionResult Create([Bind(Include = "id,name,jobtitle,number,address")] Employee employee)
            {
                if (ModelState.IsValid)
                {
                    db.EmployeeContext.Add(employee);
                    db.SaveChanges();
                    return RedirectToAction("Index", "CompanyEmployee");
                }
    
                return View(employee);
            }
    }

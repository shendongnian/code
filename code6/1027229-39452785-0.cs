    public class TestController<T> : Controller where T : class
    {
        const string PK = "Id";
        protected Models.Entities con;
        protected System.Data.Entity.DbSet<T> model;
        public TestController()
        {
            con = new Models.Entities();
            model = con.Set<T>();
        }
        // GET: Default
        public virtual ActionResult Index()
        {
            ViewBag.Result = TempData["Result"];
            TempData["Result"] = null;
            var list = model.ToList();
            return View(list);
        }
        [HttpGet]
        public virtual ActionResult AddEdit(string id)
        {
            int nId = 0;
            int.TryParse(id, out nId);
            var item = model.Find(nId);
            return View(item);
        }
        [HttpPost]
        public virtual ActionResult AddEdit(T item)
        {
            TestUpdate(item);
            con.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public virtual ActionResult Remove(string id)
        {
            int nId = 0;
            int.TryParse(id, out nId);
            if (nId != 0)
            {
                var item = model.Find(nId);
                con.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                con.SaveChanges();
            }
            return Redirect(Request.UrlReferrer.ToString());
        }
        private void TestUpdate(object item)
        {
            var props = item.GetType().GetProperties();
            foreach (var prop in props)
            {
                object value = prop.GetValue(item);
                if (prop.PropertyType.IsInterface && value != null)
                {
                    foreach (var iItem in (System.Collections.IEnumerable)value)
                    {
                        TestUpdate(iItem);
                    }
                }
            }
            int id = (int)item.GetType().GetProperty(PK).GetValue(item);
            if (id == 0)
            {
                con.Entry(item).State = System.Data.Entity.EntityState.Added;
            }
            else
            {
                con.Entry(item).State = System.Data.Entity.EntityState.Modified;
            }
            
        }
    }

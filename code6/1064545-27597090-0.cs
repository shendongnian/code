            // GET: CustomerDetail
        public async Task<ActionResult> Index(int CustomerNameID)
        {
            IQueryable<CustomerDetail> CustomerDetail = db.CustomerDetails
               .Where(c => c.CustomerNameID == CustomerNameID)
               .OrderBy(d => d.CustomerNameID)
               .Include(d => d.CustomerName);
     
            return View(await CustomerDetail.ToListAsync());
        }

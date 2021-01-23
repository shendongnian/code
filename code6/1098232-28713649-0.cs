        public async Task<ActionResult> Details(int? id)
        {
            db.Configuration.LazyLoadingEnabled = true;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TableServiceProvider tableServiceProvider = await db.TableServiceProviders.FindAsync(id);
            if (tableServiceProvider == null)
            {
                return HttpNotFound();
            }
            return View(tableServiceProvider);
        }

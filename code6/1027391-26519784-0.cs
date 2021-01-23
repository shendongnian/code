        [Route("TvShows/{slug}")]
        public ActionResult Details(string slug)
        {
            if (slug == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tv tv = db.Tv.Where(x => x.TvTitle == slug).FirstOrDefault();
            if (tv == null)
            {
                return HttpNotFound();
            }
            return View(tv);
        }

        [HttpPost]
        public ActionResult Index(TheaterShowTimeViewModel model)
        {
            if (ModelState.IsValid)
            {
                InsertOrUpdateTheaterShowTime(model);
                model.TheaterShowTimeList=_theaterShowTimeService.GetAllTheaterShowTime();
                //return RedirectToAction("Index", new { id = model.TheaterID });
                //return Json(model.TheaterShowTimeList);
                return PartialView("_TheaterShowTimeList", model.TheaterShowTimeList);
            }
            return View(model);
        }

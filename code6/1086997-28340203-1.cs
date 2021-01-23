        public ActionResult New ()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult New (NewPlaceVM vm)
		{
			if (ModelState.IsValid && vm != null)
			{
				var model = Mapper.Map<NewPlaceVM, Place>(vm);
				_place.New(model);
				return RedirectToAction("Index");
			}
			return View(vm);
		}

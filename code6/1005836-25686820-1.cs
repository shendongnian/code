        [HttpPost]
        public ActionResult Test(TestCompareModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);
            return RedirectToAction("Index");
        }

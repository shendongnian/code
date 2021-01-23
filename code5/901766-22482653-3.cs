        [HttpPost]
        public ActionResult Delete(int id)
        {
            _provider.Delete(id);
            return View();
        }

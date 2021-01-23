        [Authorize(Roles = "Administrator")]   // this is the line where your membership provider checks if current user in "Administrator" role
        public ActionResult ProductList(string keyword, int? page)
        {
            return View(MainService.GetProducts(keyword, page));
        }
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int id)
        {
            MainService.Delete(id);
            return RedirectToAction("ProductList");
        }

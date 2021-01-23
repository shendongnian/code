        [HttpPost]//<--Remove this
        public ActionResult AddToCart(int id)
        {
            _shoppingCart.Add(id, 1);
            return RedirectToAction("Index");
        }

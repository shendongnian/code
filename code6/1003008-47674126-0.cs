     [ChildActionOnly]
        public ActionResult CartSummary()
        {   
            ViewData["CartCount"] = 3; // count Qty in your cart
            return PartialView("CartSummary");
        }

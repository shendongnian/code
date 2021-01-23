        public ActionResult DliAction(string removeDli, string performDli)
        {
            if (string.IsNullOrEmpty(performDli))
            {
                ...
            }
            else if (string.IsNullOrEmpty(removeDli))
            {
                ...
            }
            return View();
        }

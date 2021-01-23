        public ActionResult Page2()
        {
            Impaire impa = TempData["impa"] as Impaire;
            try
            {
                User u = (User)Session["user"];
                if (u.Login == null) RedirectToAction("Index", "Home");
            }
            catch { return RedirectToAction("Index", "Home"); }
            if (impa == null)
            {
                return View();
            }
            return View(impa);
        }

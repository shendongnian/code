           public ActionResult TestSession()
        {
            List<int> ids = new List<int> { 1, 2, 3, 4, 5 };
            if (Session["myIds"] as List<int> != null)
            {
                (Session["myIds"] as List<int>).AddRange(ids);
            }
            else
            {
                Session["myIds"] = ids;
            }
            return RedirectToAction("Index");
        }
        public ActionResult TestSession2()
        {
            List<int> ids = new List<int> { 11, 12, 13, 14, 15 };
            if (Session["myIds"] as List<int> != null)
            {
                (Session["myIds"] as List<int>).AddRange(ids);
            }
            else
            {
                Session["myIds"] = ids;
            }
            return RedirectToAction("Index");
        }

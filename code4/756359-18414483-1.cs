        public ActionResult AddWorker(List<string> names)
        {
            List<String> strings = new List<string>();
            if (Session["List"] != null)
            {
                strings = (List<String>)Session["List"];
            }
            foreach (var s in names)
            {
                strings.Add(s);
            }
            Session["List"] = strings;
            return Json(strings);
        }

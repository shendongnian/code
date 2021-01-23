     [HttpPost]
        public ActionResult Gallery(HttpPostedFileBase file)
        {
                if (file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Images/Gallery/"), fileName);
                    file.SaveAs(path);
                }
            return RedirectToAction("Index");
        }

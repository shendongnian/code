        [HttpPost]
        public JsonResult NovoFicheiro(int id, string desc, string local, HttpPostedFileBase FileUpload)
        {
           // See de values....
            return Json(new  { ok = true, message = "", }, JsonRequestBehavior.AllowGet);
        }

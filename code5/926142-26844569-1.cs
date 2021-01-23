        [HttpPost]
        public ActionResult SaveSnapshot()
        {
            bool saved = false;
            if (Request.Form["base64data"] != null) {
                string image = Request.Form["base64data"].ToString();
                byte[] data = Convert.FromBase64String(image);
                var path = Path.Combine(Server.MapPath("~/Upload"), "snapshot.png");
                System.IO.File.WriteAllBytes(path, data);
                saved = true;
            }
            return Json(saved ? "image saved" : "image not saved");
        }

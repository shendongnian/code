        [HttpPost]
        public JsonResult AddNewImage(UserModel user)
        {
            ReturnArgs r = new ReturnArgs();
            repo.AddUser(user) // add your user to DB here
            
            SaveImages(user.Id);
            r.Status = 200;
            r.Message = "OK!";
            return Json(r);
        }
        private void SaveImages(string userid)
        {
            for (var i = 0; i < Request.Files.Count; i++)
            {
                var file = Request.Files[i] as HttpPostedFileBase;
                string fileName = userid + "_" + i;
                // saving file to DB here, but you can do what you want with
                // the inputstream
                repo.SaveImage(fileName, file.InputStream, file.ContentType);
            }
        }

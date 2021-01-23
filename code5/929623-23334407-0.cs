               [HttpPost]
               public ActionResult Update(item, HttpPostedFileBase files)
                {
                 if (files != null && files.ContentLength > 0)
                   {
                    string fileName = Path.GetFileName(files.FileName);
                     var physicalPath = path.Combine(HttpContext.Request.MapPath("~/Content/uploads"), fileName);
                     item.Photo = physicalPath;
                     files.SaveAs(physicalPath);
                     return Json(new { Photo = fileName }, "text/plain");
                  } 
             return Json(new[] { item });
               }

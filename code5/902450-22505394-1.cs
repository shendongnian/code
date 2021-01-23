            [HttpPost]
            [ValidateAntiForgeryToken]
            public void YourAction(IEnumerable<HttpPostedFileBase> files, string FirstName, string LastName)
            {
                if (files != null)
                {
                    foreach (var file in files)
                    {
                        // Verify that the user selected a file
                        if (file != null && file.ContentLength > 0)
                        {
                            // extract only the fielname
                            var fileName = Path.GetFileName(file.FileName);
                            // TODO: need to define destination
                            var path = Path.Combine(Server.MapPath("~/Upload"), fileName);
                            file.SaveAs(path);
                        }
                    }
                }
            }

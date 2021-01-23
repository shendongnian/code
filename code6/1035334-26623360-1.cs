      HttpPostedFileBase resume = Request.Files["txtImageUpload"];
            if (resume != null && resume.ContentLength > 0)
            {
                var fileName = Path.GetFileName(resume.FileName);
                var path = Path.Combine(Server.MapPath("~/Resumes"), fileName);//you can give what ever you want
                resume.SaveAs(path);
            }

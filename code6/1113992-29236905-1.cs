    HttpPostedFile file = Request.Files["doc"];
            if(file!=null)
            {
                string fname = Path.GetFileName(file.FileName);
                file.SaveAs(Server.MapPath(Path.Combine(fname)));
                Response.Write("done " + fname);
            }
            else
            {
                Response.Write("file empty");
            }

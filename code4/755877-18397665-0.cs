     string FileName = Path.Combine(Server.MapPath("~/physical folder"), attFileName);
                System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
                response.ClearContent();
                response.Clear();
               
         Response.AddHeader("Content-Disposition", string.Format("attachment; filename = \"{0}\"", System.IO.Path.GetFileName(FileName)));
                response.TransmitFile(FileName);
                response.Flush();
                response.End();

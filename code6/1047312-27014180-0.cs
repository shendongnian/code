    HttpResponse response = HttpContext.Current.Response;
                string xmlString = divLogResults.InnerText;
                string fileName = "ExportedForm.xml";
                response.StatusCode = 200;
                response.AddHeader("content-disposition", "attachment; filename=" + fileName);
                response.AddHeader("Content-Transfer-Encoding", "binary");
                //response.AddHeader("Content-Length", _Buffer.Length.ToString());
                response.ContentType = "application-download";
                response.Write(xmlString);

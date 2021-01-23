     HttpResponseMessage objResponse = Request.CreateResponse(HttpStatusCode.OK);               
     objResponse.Content = new StreamContent(new FileStream(HttpContext.Current.Server.MapPath("~/FolderName/" + FileName), FileMode.Open, FileAccess.Read));
     objResponse.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
     objResponse.Content.Headers.ContentDisposition.FileName = FileName;
     return objResponse;

    public class UploadFileController : ApiController
    {
        // POST api/<controller>
        public HttpResponseMessage Post()
        {
            HttpResponseMessage result = null;
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {
                string prevurl = HttpContext.Current.Request.ServerVariables["HTTP_REFERER"];
                var docfiles = new List<string>();
                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];
                    int hasheddate = DateTime.Now.GetHashCode();
                    string changed_name = hasheddate.ToString().Substring(0, 4) + postedFile.FileName;
                    var filePath = HttpContext.Current.Server.MapPath("~/Images/" + changed_name);
                    postedFile.SaveAs(filePath); // save the file to a folder "Images" in the root of your app
                    changed_name = @"~\Images\" + changed_name; //store this complete path to database
                    docfiles.Add(changed_name);
                }
                result = Request.CreateResponse(HttpStatusCode.Created, docfiles);
            }
            else
            {
                result = Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            return result;
        }
    }

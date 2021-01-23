    [HttpPost]
        [ActionName("Index")]
        public HttpResponseMessage Index()
            {
                HttpResponseMessage result = null;
                var httpRequest = HttpContext.Current.Request;
        
                // Check if files are available
                if (httpRequest.Files.Count > 0)
                {
                    var files = new List<string>();
        
                    // interate the files and save on the server
                    foreach (string file in httpRequest.Files)
                    {
                        var postedFile = httpRequest.Files[file];
                        var filePath = HttpContext.Current.Server.MapPath("~/" + postedFile.FileName);
                        postedFile.SaveAs(filePath);
        
                        files.Add(filePath);
                    }
        
                    // return result
                    result = Request.CreateResponse(HttpStatusCode.Created, files);
                }
                else
                {
                    // return BadRequest (no file(s) available)
                    result = Request.CreateResponse(HttpStatusCode.BadRequest);
                }
        
                return result;
            }

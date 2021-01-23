        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("myobjdownload")]
        public HttpResponseMessage DownloadMyObj(string id)
        {
            try
            {
                var myObj = GetMyObj(id); // however you do this                
                if (null != myObj )
                {
                    HttpResponseMessage result = Request.CreateResponse(HttpStatusCode.OK);
                    byte[] bytes = GetMyObjBytes(id); // however you do this
                    result.Content = new StreamContent(bytes); 
                    result.Content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/pdf");
                    result.Content.Headers.LastModified = DateTimeOffset.Now;  
                    result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue(DispositionTypeNames.Attachment)
                    {
                        FileName = string.Format("{0}.pdf", id),
                        Size = bytes.length,
                        CreationDate = DateTimeOffset.Now,
                        ModificationDate = DateTimeOffset.Now
                    };
                     return  result;
                }
            }
            catch (Exception e)
            {
                // log, throw 
            }
            return null;
        }

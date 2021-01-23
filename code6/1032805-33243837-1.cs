     public class UploadController : ApiController
     {
            [HttpPost]
            [Route("upload/{targetFolder:int}")]
            [ValidateMimeMultipartContentFilter]
            public async Task<IHttpActionResult> UploadDocument(int targetFolder)
            {
                var uploadFileService = new UploadFileService();
                UploadProcessingResult uploadResult = await uploadFileService.HandleRequest(Request);
    
                if (uploadResult.IsComplete)
                {
                    // do other stuff here after file upload complete    
                    return Ok();
                }
    
                return Ok(HttpStatusCode.Continue);
    
            }
    }

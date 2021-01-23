    // POST: api/Courses/{courseId}/Submissions/Add
    [HttpPost]
    [ValidateModelState]
    [ValidateMimeMultipartContent]
    [PermissionsAuthorize(CoursePermissions.CanCreateSubmissions)]
    public async Task<HttpResponseMessage> Add(int courseId)
        {
            // the same as in the jQuery part
            const string paramName = "fileModels";
            // Put the files in a temporary location
            // this way we call ReadAsMultiPartAsync and we get access to the other data submitted
            var tempPath = HttpContext.Current.Server.MapPath("~/App_Data/Temp/" + Guid.NewGuid());
            Directory.CreateDirectory(tempPath);
           
            var streamProvider = new MultipartFormDataStreamProvider(tempPath);
            var readResult = await Request.Content.ReadAsMultipartAsync(streamProvider);
            if (readResult.FormData[paramName] == null)
            {
                // We don't have the FileModels ... delete the TempFiles and return BadRequest
                Directory.Delete(tempPath, true);
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            // The files have been successfully saved in a TempLocation and the FileModels are not null
            // Validate that everything else is fine with this command
            var fileModels = JsonConvert.DeserializeObject<IEnumerable<FileModelExtension>>(readResult.FormData[paramName]).ToList();
            
            // AT THIS POINT, ON THE SERVER, WE HAVE ALL THE FILE MODELS 
            // AND ALL THE FILES ARE SAVED IN A TEMPORARY LOCATION
            
            // NEXT STEPS ARE VALIDATION OF THE INPUT AND THEN 
            // MOVING THE FILE FROM THE TEMP TO THE PERMANENT LOCATION
            // YOU CAN ACCESS THE INFO ABOUT THE FILES LIKE THIS:
            foreach (var tempFile in readResult.FileData)
                {
                    var originalFileName = tempFile.Headers.ContentDisposition.FileName.Replace("\"", string.Empty);
                    var localTempPath = tempFile.LocalFileName;
                }
        }

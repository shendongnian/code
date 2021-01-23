        [HttpPost]
        [Route("api/excel/createauditfile")]
        public IHttpActionResult CreateAuditFile(Request<AuditFile> request)
        {
            Response<FileInfo> response = new Response<FileInfo>();
            try
            {
                response.Result = _repository.CreateAuditFile(request.Parameter);
                response.IsSuccessStatusCode = true;
            }
            catch (Exception ex)
            {
                response.IsSuccessStatusCode = false;
                response.exception = ex;
            }
            return Ok<Response<FileInfo>>(response);
        }

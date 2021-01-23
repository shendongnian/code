      public class Response
        {
            /// <summary>
            /// Gets or sets a value indicating whether this instance is success.
            /// </summary>
            /// <value>
            /// <c>true</c> if this instance is success; otherwise, <c>false</c>.
            /// </value>
            public bool IsSuccess { get; set; } = false;
        
            /// <summary>
            /// Actual response if succeed 
            /// </summary>
            /// <value>
            /// Actual response if succeed 
            /// </value>
            public object Data { get; set; } = null;
        
            /// <summary>
            /// Remark if anythig to convey
            /// </summary>
            /// <value>
            /// Remark if anythig to convey
            /// </value>
            public string Remark { get; set; } = string.Empty;
            /// <summary>
            /// Gets or sets the error message.
            /// </summary>
            /// <value>
            /// The error message.
            /// </value>
            public object ErrorMessage { get; set; } = null;
        
           
        }  
        
 
    [HttpGet]
            public IHttpActionResult Employees()
            {
                Response _res = new Response();
                try
                { 
                    DalTest objDal = new DalTest(); 
                    _res.Data = objDal.GetTestData();
                    _res.IsSuccess = true;
                    return Ok<Response>(_res);
                }
                catch (Exception ex)
                {
                    _res.IsSuccess = false;
                    _res.ErrorMessage = ex;
                    return ResponseMessage(Request.CreateResponse(HttpStatusCode.InternalServerError, _res )); 
                } 
            }

    public class SendJobController : ApiController
        {
            public async Task<ResponseEntity<SendJobResponse>> Post([FromBody] SendJobRequest request)
            {
                return await PostAsync(request);
            }
    
            private async Task<ResponseEntity<SendJobResponse>> PostAsync(SendJobRequest request)
            {
                Task<ResponseEntity<SendJobResponse>> t = new Task<ResponseEntity<SendJobResponse>>(() =>
                {
                    ResponseEntity<SendJobResponse> _response = new ResponseEntity<SendJobResponse>();
    
                    try
                    {
                        //  
                        // some long process
                        // 
                        _response.responseStatus = "OK"; 
                        _response.responseMessage = "Success";
                        _response.responseObject = new SendJobResponse() { JobId = 1 };
    
                    }
                    catch (Exception ex)
                    {
                        _response.responseStatus = "ERROR"; 
                        _response.responseMessage = ex.Message;
                    }
    
                    return _response;
                });
    
                t.Start();
                return await t;
            }
        }

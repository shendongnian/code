    public List<MessageResponse> GetData(List<MessageRequest> messageRequests)
        {
            List<MessageResponse> responses = new List<MessageResponse>();
            try
            {
                foreach (MessageRequest request in messageRequests)
                {
                    //Set up the proxy for the right endpoint
                    SetEndpoint(request);
                    //instantiate a new Integration Request with the right proxy and program settings
                    _ir = new IntegrationRequest(_proxy, ConfigureSettings(request));
                    MessageResponse mr = new MessageResponse { Request = request };
                    using (IntegrationManager im = new IntegrationManager(_ir))
                    {
                        mr.SetData(GetData(im, request));
                    }
                    responses.Add(mr);
                }
                return responses;
            }//
            catch (Exception)
            {
                throw;
            }

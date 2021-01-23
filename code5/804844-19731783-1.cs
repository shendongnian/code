    IEnumerable<PingResponse> pingResponses = 
        await Task.Factory.StartNew(() =>
        {
            using (var prestoWcf = new PrestoWcf<IPingService>())
            {
                return prestoWcf.Service.GetAllForPingRequest(this.PingRequest);
            }
        });

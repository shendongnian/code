    [HttpGet]
    public async Task<HttpResponseMessage> Off(string id)
    {
        APNLink.Link link = LinkProvider.getDeviceLink(id, User.Identity.Name);
        if (link.LinkConnectionStatus == APNLink.ConnectionStatus.Connected)
        {
            var tcs = new TaskCompletionSource<object>();
            CallbackType test = delegate {           
               tcs.SetResult(null);
            };
            link.RelayCommand(
                APNLink.RelayNumber.Relay1, 
                APNLink.RelayCommand.OFF,
                test);
             
            // BlockForResponse();
            await tcs.Task; // non-blocking
            var msg = Request.CreateResponse(HttpStatusCode.OK);
            return msg;
        }
        // ...
    }

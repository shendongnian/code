    IRequestService request;
    
    [HttpPost]
    public HttpResponseMessage UploadFile() {
        HttpResponseMessage response;
    
        try {
            int id = 0;
            int? qId = null;
            if (int.TryParse(request.GetFormValue("id"), out id)) {
                qId = id;
            }
    
            var file = request.GetFile(0);
    
            int filePursuitId = bl.UploadFile(qId, file);
        } catch (Exception ex) {
            //...
        }
    
        return response;
    }

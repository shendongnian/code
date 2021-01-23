    public DownloadDocumentDTO
    {
        public string fileUri {get;set;}
        public object otherProp {get;set;}
    }
    [HttpPost] 
    public HttpResponseMessage DownloadDocument(DownloadDocumentDTO _dto)
    {
        ....
    }

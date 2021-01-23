    //Method Call
    IPdfService mockService = new MockPdfService() // this is a mock that implements your interface
    SendMail(cmd, mockService);
 
    //Method
    public void SendMail(ICommand command, IPdfService service)
    {
       // how should I handle this in Unit Test (mocks with NSubstitute)
       _service = new PdfService(_pdfSettings);
       var request = new DownloadRequest {FileName = "form.pdf", 
                                          FormEntry = command.FormEntry };
       var thefile = service.DownloadFile(request);
       sendEmail(command.Mail, thefile.FileByteStream);
    }

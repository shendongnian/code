    public class MyClass
    {
        private IPdfService _pdfService;
        public MyClass()
        {
            _pdfService = new PdfService(_pdfSettings);
        }        
        // Call this with your Mock pdfService
        public MyClass(IPdfService pdfService)
        {
            _pdfService = pdfSerivce;
        }
        public void SendMail(ICommand command)
        {
            var request = new DownloadRequest  { FileName = "form.pdf", FormEntry = command.FormEntry };
            var thefile = _pdfService.DownloadFile(request);
            sendEmail(command.Mail, thefile.FileByteStream)
        }
    }

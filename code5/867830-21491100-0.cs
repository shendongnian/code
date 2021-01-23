    public class MyCode
    {
        public void MyAction(FileAttachment pdf)
        {
                var attachInfo = new AttachmentInformation
                {
                    AttachmentId = Guid.NewGuid(),
                    AttachmentNote = "New Version",
                    FileName = pdf.FileName,
                    ImageByte = pdf.FileBytes
                };
    
                try
                {
                    /// do something here
                }
                catch (Exception ex)
                {
                    ///log error
                }
        }
    }
    public void GeneratePdf(MyCode onComplete)
    {
        string xpsPath = Environment.CurrentDirectory + "\\" + Id + ".xps";
    
        SaveAsXps(xpsPath, () =>
        {
            string pdfPath = Environment.CurrentDirectory + "\\" + Id + ".pdf";
            string registrationCode = ConfigurationManager.AppSettings.Get("NiXPS:RegistrationCode");
            Converter.Initialize(registrationCode);
            var outStream = new MemoryStream();
            Converter.XpsToPdf(new MemoryStream(FileToByteArray(xpsPath)), outStream);
            File.Delete(xpsPath);
            byte[] bytes = outStream.ToArray();        
            var attachment = new FileAttachment
            {
                ContentType = "application/pdf",
                FileBytes = bytes,
                FileName = fooId + ".pdf"          
            };
            onComplete.MyAction(attachment);
        });
    }
    public void GenerateCurrentPdf(FooResponse response)
    {
        if (response.Success)
        {
            var act = new MyCode();
            GeneratePdf(act);
        }
    }

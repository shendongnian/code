    using System.IO;
    
    public void MyWordFileReaderMethod()
    {
       string filePath = @"c:\example.docx";
       var file = File.ReadAllBytes(filePath);
    }

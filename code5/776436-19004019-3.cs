      public static HttpWebResponse Upload(HttpWebRequest req, UploadFile[] files, NameValueCollection form)
        
        {
        
        List<MimePart> mimeParts = new List<MimePart>();
        
        try
        
        {
        
        foreach (string key in form.AllKeys)
        
        {
        
        StringMimePart part = new StringMimePart();
        
        part.Headers["Content-Disposition"] = "form-data; name=\"" + key + "\"";
        
        part.StringData = form[key];
        
        mimeParts.Add(part);
        
        }
        
        int nameIndex = 0;
        
        foreach (UploadFile file in files)
        
        {
        
        StreamMimePart part = new StreamMimePart();
        
        if (string.IsNullOrEmpty(file.FieldName))
        
        file.FieldName = "file" + nameIndex++;
        
        part.Headers["Content-Disposition"] = "form-data; name=\"" + file.FieldName + "\"; filename=\"" + file.FileName + "\"";
        
        part.Headers["Content-Type"] = file.ContentType;
        
        part.SetStream(file.Data);
        
        mimeParts.Add(part);
        
        }
        
        string boundary = "----------" + DateTime.Now.Ticks.ToString("x");
        
        req.ContentType = "multipart/form-data; boundary=" + boundary;
        
        req.Method = "POST";
        
        long contentLength = 0;
        
        byte[] _footer = Encoding.UTF8.GetBytes("--" + boundary + "--\r\n");
        
        foreach (MimePart part in mimeParts)
        
        {
        
        contentLength += part.GenerateHeaderFooterData(boundary);
        
        }
        
        req.ContentLength = contentLength + _footer.Length;
        
        byte[] buffer = new byte[8192];
        
        byte[] afterFile = Encoding.UTF8.GetBytes("\r\n");
        
        int read;
        
        using (Stream s = req.GetRequestStream())
        
        {
        
        foreach (MimePart part in mimeParts)
        
        {
        
        s.Write(part.Header, 0, part.Header.Length);
        
        while ((read = part.Data.Read(buffer, 0, buffer.Length)) > 0)
        
        s.Write(buffer, 0, read);
        
        part.Data.Dispose();
        
        s.Write(afterFile, 0, afterFile.Length);
        
        }
        
        s.Write(_footer, 0, _footer.Length);
        
        }
        
        return (HttpWebResponse)req.GetResponse();
        
        }
        
        catch
        
        {
        
        foreach (MimePart part in mimeParts)
        
        if (part.Data != null)
        
        part.Data.Dispose();
        
        throw;
        
        }
        
        }
        
    The Classes Used Are:
    **StringMimePart.cs**
       using System;
        
        using System.Collections.Generic;
        
        using System.Text;
        
        using System.IO;
        
        namespace UploadHelper
        
        {
        
        public class StringMimePart : MimePart
        
        {
        
        Stream _data;
        
        public string StringData
        
        {
        
        set
        
        {
        
        _data = new MemoryStream(Encoding.UTF8.GetBytes(value));
        
        }
        
        }
        
        public override Stream Data
        
        {
        
        get
        
        {
        
        return _data;
        
        }
        
        }
        
        }
        
        }
    
    **StreamMimePart.cs**
    
    　
    
    using System;
    
    using System.Collections.Generic;
    
    using System.Text;
    
    using System.IO;
    
    namespace UploadHelper
    
    {
    
    public class StreamMimePart : MimePart
    
    {
    
    Stream _data;
    
    public void SetStream(Stream stream)
    
    {
    
    _data = stream;
    
    }
    
    public override Stream Data
    
    {
    
    get
    
    {
    
    return _data;
    
    }
    
    }
    
    }
    
    }
    
    **UploadFile.cs**
    
    using System;
    
    using System.Collections.Generic;
    
    using System.Text;
    
    using System.IO;
    
    namespace UploadHelper
    
    {
    
    public class UploadFile
    
    {
    
    Stream _data;
    
    string _fieldName;
    
    string _fileName;
    
    string _contentType;
    
    public UploadFile(Stream data, string fieldName, string fileName, string contentType)
    
    {
    
    _data = data;
    
    _fieldName = fieldName;
    
    _fileName = fileName;
    
    _contentType = contentType;
    
    }
    
    public UploadFile(string fileName, string fieldName, string contentType)
    
    : this(File.OpenRead(fileName), fieldName, Path.GetFileName(fileName), contentType)
    
    { }
    
    public UploadFile(string fileName)
    
    : this(fileName, null, "application/octet-stream")
    
    { }
    
    public Stream Data
    
    {
    
    get { return _data; }
    
    set { _data = value; }
    
    }
    
    public string FieldName
    
    {
    
    get { return _fieldName; }
    
    set { _fieldName = value; }
    
    }
    
    public string FileName
    
    {
    
    get { return _fileName; }
    
    set { _fileName = value; }
    
    }
    
    public string ContentType
    
    {
    
    get { return _contentType; }
    
    set { _contentType = value; }
    
    }
    
    }
    
    }
    
    **No Let Us Send the Files from any directory and read the response:**
  
     string[] enrolldirect = Directory.GetDirectories("C://YourDirectoryPathInWhichYouHaveFilesToPost").ToArray();
     //Building webrequest to your url (might be servlet or other)
       HttpWebRequest webreq =    (HttpWebRequest)WebRequest.Create("http://www.IamMohdIlyasFromHyderabadIndia.WriteYourServeletUrlToWhomeYouAreUploadingFiles");
      NameValueCollection nvc = new NameValueCollection();
     //If you required then only pass it else don't pass and remove it from function too
      nvc.Add("YourNVCName1", "YourNVCValue1");
      nvc.Add("YourNVCName2", "YourNVCValue2");
      string[] enrollfiles = Directory.GetFiles(dir).ToArray();
      UploadFile[] files = new UploadFile[enrollfiles.Length];
      for (int i = 0; i < enrollfiles.Length; i++)
      {
      files[i] = new UploadFile(enrollfiles[i]);
      }
      HttpWebRequest req = (HttpWebRequest)WebRequest.Create(posturl);
      HttpWebResponse resp = HttpUploadHelper.Upload(req, files, nvc);
      StreamReader respreader = new StreamReader(resp.GetResponseStream());
      //Now read the Response..Enjoy....
      string response = respreader.ReadToEnd();

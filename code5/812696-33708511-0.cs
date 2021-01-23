    Dictionary<string, object> _headerContents = new Dictionary<string, object>();
    const String _lineEnd = "\r\n";
    const String _twoHyphens = "--";
    const String _boundary = "*****";
    private async void UploadFile_OnTap(object sender, System.Windows.Input.GestureEventArgs e)
    {
       Uri serverUri = new Uri("http:www.myserver.com/Mp4UploadHandler", UriKind.Absolute);    
       string fileContentType = "multipart/form-data";       
       byte[] _boundarybytes = Encoding.UTF8.GetBytes(_twoHyphens + _boundary + _lineEnd);
       byte[] _trailerbytes = Encoding.UTF8.GetBytes(_twoHyphens + _boundary + _twoHyphens + _lineEnd);
       Dictionary<string, object> _headerContents = new Dictionary<string, object>();
       SetEndHeaders();  // to add some extra parameter if you need
    
       httpWebRequest = (HttpWebRequest)WebRequest.Create(serverUri);
       httpWebRequest.ContentType = fileContentType + "; boundary=" + _boundary;
       httpWebRequest.Method = "POST";
       httpWebRequest.AllowWriteStreamBuffering = false;  // get response after upload header part
    
       var fileName = Path.GetFileName(MediaStorageFile.Path);    
       Stream fStream = (await MediaStorageFile.OpenAsync(Windows.Storage.FileAccessMode.Read)).AsStream(); //MediaStorageFile is a storage file from where you want to upload the file of your device    
       string fileheaderTemplate = "Content-Disposition: form-data; name=\"{0}\"" + _lineEnd + _lineEnd + "{1}" + _lineEnd;    
       long httpLength = 0;
       foreach (var headerContent in _headerContents) // get the length of upload strem
       httpLength += _boundarybytes.Length + Encoding.UTF8.GetBytes(string.Format(fileheaderTemplate, headerContent.Key, headerContent.Value)).Length;
    
       httpLength += _boundarybytes.Length + Encoding.UTF8.GetBytes("Content-Disposition: form-data; name=\"uploadedFile\";filename=\"" + fileName + "\"" + _lineEnd).Length
                                           + Encoding.UTF8.GetBytes(_lineEnd).Length * 2 + _trailerbytes.Length;
       httpWebRequest.ContentLength = httpLength + fStream.Length;  // wait until you upload your total stream 
                            
        httpWebRequest.BeginGetRequestStream((result) =>
        {
           try
           {
             HttpWebRequest request = (HttpWebRequest)result.AsyncState;
             using (Stream stream = request.EndGetRequestStream(result))
             {
                foreach (var headerContent in _headerContents)
                {
                   WriteToStream(stream, _boundarybytes);
                   WriteToStream(stream, string.Format(fileheaderTemplate, headerContent.Key, headerContent.Value));
                 }
    
                 WriteToStream(stream, _boundarybytes);
                 WriteToStream(stream, "Content-Disposition: form-data; name=\"uploadedFile\";filename=\"" + fileName + "\"" + _lineEnd);
                 WriteToStream(stream, _lineEnd);
                                        
                 int bytesRead = 0;
                 byte[] buffer = new byte[2048];  //upload 2K each time
    
                 while ((bytesRead = fStream.Read(buffer, 0, buffer.Length)) != 0)
                 {
                   stream.Write(buffer, 0, bytesRead);
                   Array.Clear(buffer, 0, 2048); // Clear the array.
                  }
    
                  WriteToStream(stream, _lineEnd);
                  WriteToStream(stream, _trailerbytes);
                  fStream.Close();
             }
             request.BeginGetResponse(a =>
             { //get response here
                try
                {
                   var response = request.EndGetResponse(a);
                   using (Stream streamResponse = response.GetResponseStream())
                   using (var memoryStream = new MemoryStream())
                   {   
                       streamResponse.CopyTo(memoryStream);
                       responseBytes = memoryStream.ToArray();  // here I get byte response from server. you can change depends on server response
                   }    
                  if (responseBytes.Length > 0 && responseBytes[0] == 1)
                     MessageBox.Show("Uploading Completed");
                  else
                      MessageBox.Show("Uploading failed, please try again.");
                }
                catch (Exception ex)
                {}
              }, null);
          }
          catch (Exception ex)
          {
             fStream.Close();                             
          }
       }, httpWebRequest);
    }
    
    private static void WriteToStream(Stream s, string txt)
    {
       byte[] bytes = Encoding.UTF8.GetBytes(txt);
       s.Write(bytes, 0, bytes.Length);
     }
    
     private static void WriteToStream(Stream s, byte[] bytes)
     {
       s.Write(bytes, 0, bytes.Length);
     }
    
     private void SetEndHeaders()
     {
       _headerContents.Add("sId", LocalData.currentUser.SessionId);
       _headerContents.Add("uId", LocalData.currentUser.UserIdentity);
       _headerContents.Add("authServer", LocalData.currentUser.AuthServerIP);
       _headerContents.Add("comPort", LocalData.currentUser.ComPort);
     }

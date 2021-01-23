    Net.HttpWebRequest objRequest = Net.WebRequest.Create("http://localhost:12345/handler.ashx");
    
    objRequest.Method = "POST";
    objRequest.UserAgent = "Some User Agent";
    objRequest.ContentLength = output.Length;
    objRequest.ContentType = "text/xml";
    
    IO.StreamWriter objStreamWriter = new IO.StreamWriter(objRequest.GetRequestStream, System.Text.Encoding.ASCII);
    objStreamWriter.Write(output);
    objStreamWriter.Flush();
    objStreamWriter.Close();
    
    Net.WebResponse objWebResponse = objRequest.GetResponse();
    XmlReaderSettings objXmlReaderSettings = new XmlReaderSettings();
    objXmlReaderSettings.DtdProcessing = DtdProcessing.Ignore;
    XmlReader objXmlReader = XmlReader.Create(objWebResponse.GetResponseStream, objXmlReaderSettings);
    
    // Pipes the stream to a higher level stream reader with the required encoding format.  
    IO.MemoryStream objMemoryStream2 = new IO.MemoryStream();
    XmlWriter objXmlWriter2 = XmlWriter.Create(objMemoryStream2, objXmlWriterSettings);
    objXmlWriter2.WriteNode(objXmlReader, true);
    objXmlWriter2.Flush();
    objXmlWriter2.Close();
    objWebResponse.Close();
    
    objMemoryStream2.Position = 0;
    
    StreamReader objStreamReader = new StreamReader(objMemoryStream2, Encoding.UTF8);
    Console.WriteLine(objStreamReader.ReadToEnd() + Environment.NewLine);
    objStreamReader.Close();

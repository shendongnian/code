    //Open binary stream from library
    ClientResult<Stream> stream = file.OpenBinaryStream();
    clientContext.Load(file);
    clientContext.ExecuteQuery();
    //Initialize PdfReader
    var reader = new PdfReader(stream.Value);
    //We will write output file into memory. You can use temp file of course.
    var ms = new MemoryStream();
    //Initialize PdfStamper
    var stamper = new PdfStamper(reader, ms);
    //Tell stamper not to close stream when stamper itself is being closed
    stamper.Writer.CloseStream = false;
    //Change Title to "New Document Title"
    var moreInfo = new Dictionary<string, string>();
    moreInfo["Title"] = "New Document Title";
    stamper.MoreInfo = moreInfo;
    //Close stamper, readed
    stamper.Close();
    reader.Close();
    //Flush memory stream and set it position to start
    ms.Flush();
    ms.Position = 0;
    //Update library item with new content
    var bi = new FileSaveBinaryInformation();
    bi.ContentStream = ms;
    file.SaveBinary(bi);
    clientContext.Load(file);
    clientContext.ExecuteQuery();
    //Finally, close the stream
    ms.Close();

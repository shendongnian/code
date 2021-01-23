     try
	 { 
	    var result = await insert.UploadAsync();
	 }
	 catch(Exception ex)
	 {
	    Console.WriteLine("Upload Filed. " + ex.Message);
	 }
     finally
	 {
	     Logger.Debug("Closing the stream");
         uploadStream.Dispose();
         Logger.Debug("The stream was closed");
	 }

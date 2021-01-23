    public class ZipSaver
    {
     private ZipFile _zipFile;
 
     public ZipSaver() // add necessary parameters
     { 
        _zipFile = new ZipFile();
        _zipFile.OnSaveCompleted += ZipFile_OnSaveCompleted;
     } 
     public void StartZippingFile()
     { 
     // pretty much the code you have in your question with the exception of the using block around it.
     } 
     public void ZipFile_OnSaveCompleted() // Add necessary parameters from OnSaveCompleted delegate
     {
     // Delete application data 
     // Dispose of ZipFile.
     }
    }

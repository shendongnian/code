<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <startup>
    <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.6.1" />
  </startup>
  <appSettings>
    <add key="FtpHost" value="127.0.0.1"/>
    <add key="FtpUser" value="username"/>
    <add key="FtpPassword" value="password123"/>
    <add key="FtpDirectory" value="/INTERESTING FILES/DATA"/>
    <add key="FileExtension" value=".txt"/>
    <add key="DownloadTo" value="C:\Downloads"/>
    <add key="DeleteFilesAfterDownload" value="false"/>
  </appSettings>
</configuration>
And a little FTP Library:
    namespace FTPDownloadAdapter {
        class Program
        {
            private static readonly string FtpHost = ConfigurationManager.AppSettings["FtpHost"];
            private static readonly string FtpUser = ConfigurationManager.AppSettings["FtpUser"];
            private static readonly string FtpPassword = ConfigurationManager.AppSettings["FtpPassword"];
            private static readonly string FtpDirectory = ConfigurationManager.AppSettings["FtpDirectory"];
            private static readonly string FileExtension = ConfigurationManager.AppSettings["FileExtension"];
            private static readonly string DownloadTo = ConfigurationManager.AppSettings["DownloadTo"];
            private static readonly string DeleteFilesAfterDownload = ConfigurationManager.AppSettings["DeleteFilesAfterDownload"];
    
            static void Main(string[] args)
            {
    
    
                try{
           
    				
                    DownloadFiles();
    
                
                }
                catch (Exception er){
                    Console.WriteLine(er.ToString());
                }
    
            }
    
            private static void DownloadFiles(){
    		
                // create an FTP client
                var client = new FtpClient(FtpHost) { Credentials = new NetworkCredential(FtpUser, FtpPassword) };
    
                // if you don't specify login credentials, we use the "anonymous" user account
    
    
                // begin connecting to the server
                client.Connect();
    
        			
                Console.WriteLine($"Retrieving files with extension [{FileExtension}] from directory [{FtpDirectory}]");
    
             
                foreach (FtpListItem item in client.GetListing(FtpDirectory)){
                    // if this is a file
                    if (item.Type == FtpFileSystemObjectType.File && (Path.GetExtension(item.FullName) == FileExtension)){
                        // get the file size
                        long size = client.GetFileSize(item.FullName);
    
                        // get modified date/time of the file or folder
                        DateTime time = client.GetModifiedTime(item.FullName);
    
                        // calculate a hash for the file on the server side (default algorithm)
                        FtpHash hash = client.GetHash(item.FullName);
    
                        // download the file 
                        var fileName = Path.GetFileName(item.FullName);
                        var saveFilePath = Path.Combine(DownloadTo, fileName ?? throw new InvalidOperationException("File Appears to not have a name"));
    
                        Console.WriteLine($"Downloading file: {fileName}");
                        client.DownloadFile(localPath: saveFilePath, remotePath: item.FullName);
    
                        if (DeleteFilesAfterDownload == "true")
                        {
                            Console.WriteLine($"DeleteFilesAfterDownload is true, Deleting file from FTP : {item.FullName}");
    						
                            client.DeleteFile(item.FullName);
    						
                            Console.WriteLine("File deletion success");
                        }
                        else
                        {
    
                            Console.WriteLine($"DeleteFilesAfterDownload not true, skip deleting : {item.FullName}");
    
                        }
    
                    }
                }
            }
        }
    }
  [1]: https://github.com/robinrodricks/FluentFTP

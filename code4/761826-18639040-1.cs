    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.ServiceProcess;
    using System.Text;
    using System.Threading.Tasks;
    namespace DirectoryWatcher
    {
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            #if(!DEBUG)
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[] 
                { 
                    new Service1() 
                };
                ServiceBase.Run(ServicesToRun);
            #else
                Service1 MyServ = new Service1();
                MyServ.OnDebug();
                System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
            #endif
        }
    }
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.ServiceProcess;
    using System.Text;
    using System.Threading.Tasks;
    using System.Net;
    using System.Windows.Forms;
    using System.Configuration;
    namespace DirectoryWatcher
    {
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
            
            if (!System.Diagnostics.EventLog.SourceExists("MySource"))
            {
                System.Diagnostics.EventLog.CreateEventSource(
                    "MySource", "MyNewLog");
            }
            eventLog1.Source = "MySource";
            eventLog1.Log = "MyNewLog";
        }
        private static string fileName = "",filePath= "";
        private static string[] pathArr;
        static ftpClass1 ftpDavid = new      ftpClass1(ConfigurationManager.AppSettings["ftpServer"], ConfigurationManager.AppSettings["ftpUser"], ConfigurationManager.AppSettings["ftpPassword"]);
        //ftpClass ftpDavid = new ftpClass();
        
        
        public void OnDebug()
        {
            OnStart(null);
        }
        protected override void OnStart(string[] args)
        {
            eventLog1.WriteEntry("In OnStart");
            FileSystemWatcher watcher = new FileSystemWatcher();//
            //StreamWriter w = File.AppendText("log.txt");
            watcher.Path = ConfigurationManager.AppSettings["watcherPath"];
            /* Watch for changes in LastAccess and LastWrite times, and
               the renaming of files or directories. */
            //watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            // Only watch text files.
            watcher.Filter = "*.*";
            //ftpClass1 ftpDavid = new ftpClass1(ConfigurationManager.AppSettings["ftpServer"], ConfigurationManager.AppSettings["ftpUser"], ConfigurationManager.AppSettings["ftpPassword"]);
            // Add event handlers.
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(FileWatcher_Created);
            watcher.Deleted += new FileSystemEventHandler(FileWatcher_Deleted);
            watcher.Renamed += new RenamedEventHandler(FileWatcher_Renamed);
            // Begin watching.
            watcher.EnableRaisingEvents = true;
           
        }
        protected override void OnStop()
        {
            eventLog1.WriteEntry("In onStop.");
        }
        protected override void OnContinue()
        {
            eventLog1.WriteEntry("In OnContinue.");
        }
        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            // Specify what is done when a file is changed, created, or deleted.
            /*
            Console.WriteLine("File: " + e.FullPath + " " + e.ChangeType);
            using (StreamWriter w = new StreamWriter("c:\\logdir\\logFileWatcherConsole.txt", true))
            {
                w.Write("\r\nLog Entry : ");
                w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                DateTime.Now.ToLongDateString());
                w.WriteLine("  :");
                w.WriteLine("  :{0}", "File : "+e.FullPath+" Changed");
                w.WriteLine("-------------------------------");
            }
            */
        }
        private static void OnRenamed(object source, RenamedEventArgs e)
        {
            // Specify what is done when a file is renamed.
            Console.WriteLine("File: {0} renamed to {1}", e.OldFullPath, e.FullPath);
            using (StreamWriter w = new StreamWriter("c:\\logdir\\logFileWatcherConsole.txt", true))
            {
                w.Write("\r\nLog Entry : ");
                w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                DateTime.Now.ToLongDateString());
            }
        }
        private static void FileWatcher_Created(object source, FileSystemEventArgs e)
        {
            //code here for newly created file or directory
            using (StreamWriter w = new StreamWriter(ConfigurationManager.AppSettings["logFile"], true))
            {
                w.Write("\r\nLog Entry : ");
                w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                DateTime.Now.ToLongDateString());
                w.WriteLine("  :");
                w.WriteLine("  :{0}", "File : " + e.FullPath + " created");
                w.WriteLine("-------------------------------");
            }
            pathArr = e.FullPath.Split('\\');
            fileName = pathArr[pathArr.Length -1];
            filePath = "";
            for (int i = 0; i < pathArr.Length -1;i++ )
            {
                filePath = filePath +  pathArr[i] +"\\";
            }
            //Ftp(fileName);
            //ftpClass1 ftp1 = new ftpClass1(ConfigurationManager.AppSettings["ftpServer"], ConfigurationManager.AppSettings["ftpUser"], ConfigurationManager.AppSettings["ftpPassword"]);
            ftpDavid.upload(fileName,filePath + fileName);
            
            
        }
        /// <summary>
        /// Event occurs when the a File or Directory is deleted
        /// </summary>
        private static void FileWatcher_Deleted(object source, FileSystemEventArgs e)
        {
            //code here for newly deleted file or directory
            using (StreamWriter w = new StreamWriter(ConfigurationManager.AppSettings["logFile"], true))
            {
                w.Write("\r\nLog Entry : ");
                w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                DateTime.Now.ToLongDateString());
                w.WriteLine("  :");
                w.WriteLine("  :{0}", "File : " + e.FullPath + " deleted");
                w.WriteLine("-------------------------------");
            }
            pathArr = e.FullPath.Split('\\');
            fileName = pathArr[pathArr.Length - 1];
            filePath = "";
            for (int i = 0; i < pathArr.Length - 1; i++)
            {
                filePath = filePath + pathArr[i] + "\\";
            }
            //Ftp(fileName);
            //ftpClass1 ftp2 = new ftpClass1(ConfigurationManager.AppSettings["ftpServer"], ConfigurationManager.AppSettings["ftpUser"], ConfigurationManager.AppSettings["ftpPassword"]);
            ftpDavid.delete(fileName);
        }
        /// <summary>
        /// Event occurs when the a File or Directory is renamed
        /// </summary>
        private static void FileWatcher_Renamed(object source, RenamedEventArgs e)
        {
            //code here for newly renamed file or directory
            using (StreamWriter w = new StreamWriter(ConfigurationManager.AppSettings["logFile"], true))
            {
                w.Write("\r\nLog Entry : ");
                w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                DateTime.Now.ToLongDateString());
                w.WriteLine("  :");
                w.WriteLine("  :{0}", "File : " + e.OldFullPath + " renamed to "+ e.FullPath);
                w.WriteLine("-------------------------------");
            }
            pathArr = e.OldFullPath.Split('\\');
            fileName = pathArr[pathArr.Length - 1];
            pathArr = e.FullPath.Split('\\');
            filePath = "";
            for (int i = 0; i < pathArr.Length - 1; i++)
            {
                filePath = filePath + pathArr[i] + "\\";
            }
            //Ftp(fileName);
            ftpDavid.rename(fileName, pathArr[pathArr.Length - 1]);
        }
        private static void Ftp(string FileName)
        {
            try
            {
                
                // Get the object used to communicate with the server.
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings["ftpServer"] + FileName);
                request.Method = WebRequestMethods.Ftp.UploadFile;
                // This example assumes the FTP site uses anonymous logon.
                request.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["ftpUser"], ConfigurationManager.AppSettings["ftpPassword"]);
                // Copy the contents of the file to the request stream.
                //fileInfo = new FileInfo(FileName);
                StreamReader sourceStream = new StreamReader(filePath +FileName);
                byte[] fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
                sourceStream.Close();
                request.ContentLength = fileContents.Length;
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(fileContents, 0, fileContents.Length);
                requestStream.Close();
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                using (StreamWriter w = new StreamWriter("c:\\logdir\\logFileWatcherConsole.txt", true))
                {
                    w.Write("\r\nLog Entry : ");
                    w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                    DateTime.Now.ToLongDateString());
                    w.WriteLine("  :");
                    w.WriteLine("  :{0}", "File : " + FileName + " uploaded");
                    w.WriteLine("-------------------------------");
                }
                response.Close();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        public static FileInfo fileInfo { get; set; }
    }
}
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;
     namespace DirectoryWatcher
     {
     class ftpClass1
     {
            private string host = null;
            private string user = null;
            private string pass = null;
            private FtpWebRequest ftpRequest = null;
            private FtpWebResponse ftpResponse = null;
            private Stream ftpStream = null;
            private int bufferSize = 2048;
            /* Construct Object */
            public ftpClass1(string hostIP, string userName, string password) { host = hostIP; user = userName; pass = password; }
            /* Download File */
            public void download(string remoteFile, string localFile)
            {
                try
                {
                    /* Create an FTP Request */
                    ftpRequest = (FtpWebRequest)FtpWebRequest.Create(host + "/" + remoteFile);
                    /* Log in to the FTP Server with the User Name and Password Provided */
                    ftpRequest.Credentials = new NetworkCredential(user, pass);
                    /* When in doubt, use these options */
                    ftpRequest.UseBinary = true;
                    ftpRequest.UsePassive = true;
                    ftpRequest.KeepAlive = true;
                    /* Specify the Type of FTP Request */
                    ftpRequest.Method = WebRequestMethods.Ftp.DownloadFile;
                    /* Establish Return Communication with the FTP Server */
                    ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                    /* Get the FTP Server's Response Stream */
                    ftpStream = ftpResponse.GetResponseStream();
                    /* Open a File Stream to Write the Downloaded File */
                    FileStream localFileStream = new FileStream(localFile, FileMode.Create);
                    /* Buffer for the Downloaded Data */
                    byte[] byteBuffer = new byte[bufferSize];
                    int bytesRead = ftpStream.Read(byteBuffer, 0, bufferSize);
                    /* Download the File by Writing the Buffered Data Until the Transfer is Complete */
                    try
                    {
                        while (bytesRead > 0)
                        {
                            localFileStream.Write(byteBuffer, 0, bytesRead);
                            bytesRead = ftpStream.Read(byteBuffer, 0, bufferSize);
                        }
                    }
                    catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                    /* Resource Cleanup */
                    localFileStream.Close();
                    ftpStream.Close();
                    ftpResponse.Close();
                    ftpRequest = null;
                }
                catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                return;
            }
            /* Upload File */
            public void upload(string remoteFile, string localFile)
            {
                try
                {
                    /* Create an FTP Request */
                    ftpRequest = (FtpWebRequest)FtpWebRequest.Create(host + remoteFile);
                    /* Log in to the FTP Server with the User Name and Password Provided */
                    ftpRequest.Credentials = new NetworkCredential(user, pass);
                    /* When in doubt, use these options */
                    ftpRequest.UseBinary = true;
                    ftpRequest.UsePassive = true;
                    ftpRequest.KeepAlive = true;
                    /* Specify the Type of FTP Request */
                    ftpRequest.Method = WebRequestMethods.Ftp.UploadFile;
                    /* Establish Return Communication with the FTP Server */
                    ftpStream = ftpRequest.GetRequestStream();
                    /* Open a File Stream to Read the File for Upload */
                    FileStream localFileStream = new FileStream(localFile, FileMode.Create);
                    /* Buffer for the Downloaded Data */
                    byte[] byteBuffer = new byte[bufferSize];
                    int bytesSent = localFileStream.Read(byteBuffer, 0, bufferSize);
                    /* Upload the File by Sending the Buffered Data Until the Transfer is Complete */
                    try
                    {
                        while (bytesSent != 0)
                        {
                            ftpStream.Write(byteBuffer, 0, bytesSent);
                            bytesSent = localFileStream.Read(byteBuffer, 0, bufferSize);
                        }
                    }
                    catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                    /* Resource Cleanup */
                    localFileStream.Close();
                    ftpStream.Close();
                    ftpRequest = null;
                }
                catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                return;
            }
            /* Delete File */
            public void delete(string deleteFile)
            {
                try
                {
                    /* Create an FTP Request */
                    ftpRequest = (FtpWebRequest)WebRequest.Create(host +  deleteFile);
                    /* Log in to the FTP Server with the User Name and Password Provided */
                    ftpRequest.Credentials = new NetworkCredential(user, pass);
                    /* When in doubt, use these options */
                    ftpRequest.UseBinary = true;
                    ftpRequest.UsePassive = true;
                    ftpRequest.KeepAlive = true;
                    /* Specify the Type of FTP Request */
                    ftpRequest.Method = WebRequestMethods.Ftp.DeleteFile;
                    /* Establish Return Communication with the FTP Server */
                    ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                    /* Resource Cleanup */
                    ftpResponse.Close();
                    ftpRequest = null;
                }
                catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                return;
            }
            /* Rename File */
            public void rename(string currentFileNameAndPath, string newFileName)
            {
                try
                {
                    /* Create an FTP Request */
                    ftpRequest = (FtpWebRequest)WebRequest.Create(host +  currentFileNameAndPath);
                    /* Log in to the FTP Server with the User Name and Password Provided */
                    ftpRequest.Credentials = new NetworkCredential(user, pass);
                    /* When in doubt, use these options */
                    ftpRequest.UseBinary = true;
                    ftpRequest.UsePassive = true;
                    ftpRequest.KeepAlive = true;
                    /* Specify the Type of FTP Request */
                    ftpRequest.Method = WebRequestMethods.Ftp.Rename;
                    /* Rename the File */
                    ftpRequest.RenameTo = newFileName;
                    /* Establish Return Communication with the FTP Server */
                    ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                    /* Resource Cleanup */
                    ftpResponse.Close();
                    ftpRequest = null;
                }
                catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                return;
            }
            /* Create a New Directory on the FTP Server */
            public void createDirectory(string newDirectory)
            {
                try
                {
                    /* Create an FTP Request */
                    ftpRequest = (FtpWebRequest)WebRequest.Create(host + "/" + newDirectory);
                    /* Log in to the FTP Server with the User Name and Password Provided */
                    ftpRequest.Credentials = new NetworkCredential(user, pass);
                    /* When in doubt, use these options */
                    ftpRequest.UseBinary = true;
                    ftpRequest.UsePassive = true;
                    ftpRequest.KeepAlive = true;
                    /* Specify the Type of FTP Request */
                    ftpRequest.Method = WebRequestMethods.Ftp.MakeDirectory;
                    /* Establish Return Communication with the FTP Server */
                    ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                    /* Resource Cleanup */
                    ftpResponse.Close();
                    ftpRequest = null;
                }
                catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                return;
            }
            /* Get the Date/Time a File was Created */
            public string getFileCreatedDateTime(string fileName)
            {
                try
                {
                    /* Create an FTP Request */
                    ftpRequest = (FtpWebRequest)FtpWebRequest.Create(host + "/" + fileName);
                    /* Log in to the FTP Server with the User Name and Password Provided */
                    ftpRequest.Credentials = new NetworkCredential(user, pass);
                    /* When in doubt, use these options */
                    ftpRequest.UseBinary = true;
                    ftpRequest.UsePassive = true;
                    ftpRequest.KeepAlive = true;
                    /* Specify the Type of FTP Request */
                    ftpRequest.Method = WebRequestMethods.Ftp.GetDateTimestamp;
                    /* Establish Return Communication with the FTP Server */
                    ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                    /* Establish Return Communication with the FTP Server */
                    ftpStream = ftpResponse.GetResponseStream();
                    /* Get the FTP Server's Response Stream */
                    StreamReader ftpReader = new StreamReader(ftpStream);
                    /* Store the Raw Response */
                    string fileInfo = null;
                    /* Read the Full Response Stream */
                    try { fileInfo = ftpReader.ReadToEnd(); }
                    catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                    /* Resource Cleanup */
                    ftpReader.Close();
                    ftpStream.Close();
                    ftpResponse.Close();
                    ftpRequest = null;
                    /* Return File Created Date Time */
                    return fileInfo;
                }
                catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                /* Return an Empty string Array if an Exception Occurs */
                return "";
            }
            /* Get the Size of a File */
            public string getFileSize(string fileName)
            {
                try
                {
                    /* Create an FTP Request */
                    ftpRequest = (FtpWebRequest)FtpWebRequest.Create(host + "/" + fileName);
                    /* Log in to the FTP Server with the User Name and Password Provided */
                    ftpRequest.Credentials = new NetworkCredential(user, pass);
                    /* When in doubt, use these options */
                    ftpRequest.UseBinary = true;
                    ftpRequest.UsePassive = true;
                    ftpRequest.KeepAlive = true;
                    /* Specify the Type of FTP Request */
                    ftpRequest.Method = WebRequestMethods.Ftp.GetFileSize;
                    /* Establish Return Communication with the FTP Server */
                    ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                    /* Establish Return Communication with the FTP Server */
                    ftpStream = ftpResponse.GetResponseStream();
                    /* Get the FTP Server's Response Stream */
                    StreamReader ftpReader = new StreamReader(ftpStream);
                    /* Store the Raw Response */
                    string fileInfo = null;
                    /* Read the Full Response Stream */
                    try { while (ftpReader.Peek() != -1) { fileInfo = ftpReader.ReadToEnd(); } }
                    catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                    /* Resource Cleanup */
                    ftpReader.Close();
                    ftpStream.Close();
                    ftpResponse.Close();
                    ftpRequest = null;
                    /* Return File Size */
                    return fileInfo;
                }
                catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                /* Return an Empty string Array if an Exception Occurs */
                return "";
            }
            /* List Directory Contents File/Folder Name Only */
            public string[] directoryListSimple(string directory)
            {
                try
                {
                    /* Create an FTP Request */
                    ftpRequest = (FtpWebRequest)FtpWebRequest.Create(host + "/" + directory);
                    /* Log in to the FTP Server with the User Name and Password Provided */
                    ftpRequest.Credentials = new NetworkCredential(user, pass);
                    /* When in doubt, use these options */
                    ftpRequest.UseBinary = true;
                    ftpRequest.UsePassive = true;
                    ftpRequest.KeepAlive = true;
                    /* Specify the Type of FTP Request */
                    ftpRequest.Method = WebRequestMethods.Ftp.ListDirectory;
                    /* Establish Return Communication with the FTP Server */
                    ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                    /* Establish Return Communication with the FTP Server */
                    ftpStream = ftpResponse.GetResponseStream();
                    /* Get the FTP Server's Response Stream */
                    StreamReader ftpReader = new StreamReader(ftpStream);
                    /* Store the Raw Response */
                    string directoryRaw = null;
                    /* Read Each Line of the Response and Append a Pipe to Each Line for Easy Parsing */
                    try { while (ftpReader.Peek() != -1) { directoryRaw += ftpReader.ReadLine() + "|"; } }
                    catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                    /* Resource Cleanup */
                    ftpReader.Close();
                    ftpStream.Close();
                    ftpResponse.Close();
                    ftpRequest = null;
                    /* Return the Directory Listing as a string Array by Parsing 'directoryRaw' with the Delimiter you Append (I use | in This Example) */
                    try { string[] directoryList = directoryRaw.Split("|".ToCharArray()); return directoryList; }
                    catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                }
                catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                /* Return an Empty string Array if an Exception Occurs */
                return new string[] { "" };
            }
            /* List Directory Contents in Detail (Name, Size, Created, etc.) */
            public string[] directoryListDetailed(string directory)
            {
                try
                {
                    /* Create an FTP Request */
                    ftpRequest = (FtpWebRequest)FtpWebRequest.Create(host + "/" + directory);
                    /* Log in to the FTP Server with the User Name and Password Provided */
                    ftpRequest.Credentials = new NetworkCredential(user, pass);
                    /* When in doubt, use these options */
                    ftpRequest.UseBinary = true;
                    ftpRequest.UsePassive = true;
                    ftpRequest.KeepAlive = true;
                    /* Specify the Type of FTP Request */
                    ftpRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                    /* Establish Return Communication with the FTP Server */
                    ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                    /* Establish Return Communication with the FTP Server */
                    ftpStream = ftpResponse.GetResponseStream();
                    /* Get the FTP Server's Response Stream */
                    StreamReader ftpReader = new StreamReader(ftpStream);
                    /* Store the Raw Response */
                    string directoryRaw = null;
                    /* Read Each Line of the Response and Append a Pipe to Each Line for Easy Parsing */
                    try { while (ftpReader.Peek() != -1) { directoryRaw += ftpReader.ReadLine() + "|"; } }
                    catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                    /* Resource Cleanup */
                    ftpReader.Close();
                    ftpStream.Close();
                    ftpResponse.Close();
                    ftpRequest = null;
                    /* Return the Directory Listing as a string Array by Parsing 'directoryRaw' with the Delimiter you Append (I use | in This Example) */
                    try { string[] directoryList = directoryRaw.Split("|".ToCharArray()); return directoryList; }
                    catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                }
                catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                /* Return an Empty string Array if an Exception Occurs */
                return new string[] { "" };
            }
    }

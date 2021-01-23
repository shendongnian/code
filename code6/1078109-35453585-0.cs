    //Using WinSCP to upload and download files
    using System;
    using System.Configuration;`
    using System.Data;
    using System.Data.SqlClient;
    using System.IO;
    using System.Text;
    
    using log4net;
    using log4net.Config;
    
    using WinSCP;
    
    namespace SynchSubscriptions
    {
        public class Program
        {
            // Initialize logger
            private static readonly ILog Logger = LogManager.GetLogger(typeof(Program));
    
            public static void Main(string[] args)
            {
                Download();
                UploadFile();
            }
    
            public static void Download()
            {           
                try
                {
                    string ftpurl = ConfigurationManager.AppSettings["FTPUrl"];
                    string ftpusername = ConfigurationManager.AppSettings["FTPUsername"];
                    string ftppassword = ConfigurationManager.AppSettings["FTPPassword"];
                    string ftpSSHFingerPrint = ConfigurationManager.AppSettings["SSHFingerPrint"];
    
                    string ftpfilepath = ConfigurationManager.AppSettings["FtpFilePath"];
                    string Download = ConfigurationManager.AppSettings["Download"];
    
                    SessionOptions sessionOptions = new SessionOptions
                    {
                        Protocol = Protocol.Sftp,
                        HostName = ftpurl,
                        UserName = ftpusername,
                        Password = ftppassword,
                        PortNumber = 22,
                        SshHostKeyFingerprint = ftpSSHFingerPrint
                    };           
    
                    using (Session session = new Session())
                    {
                        session.SessionLogPath = "";
                        session.Open(sessionOptions);
                        RemoteDirectoryInfo directory = session.ListDirectory("/Export/");
                        foreach (RemoteFileInfo fileInfo in directory.Files)
                        {
                        TransferOptions transferOptions = new TransferOptions();
                        transferOptions.TransferMode = TransferMode.Binary;
                        transferOptions.FilePermissions = null; 
                        transferOptions.PreserveTimestamp = false;  
                        transferOptions.ResumeSupport.State = TransferResumeSupportState.Off;
                        TransferOperationResult transferResult;
                        transferResult = session.GetFiles("/Export/" + fileInfo.Name, Download, false, transferOptions);
                        transferResult.Check();
                        }
                    }
                }
                catch (Exception ex)
                {              
                }
            }
    
           
            private static bool UploadFile()
            {
                bool success = false;
                string sourcefilepath = "Input File Path";
                try
                {
                    string ftpurl = ConfigurationManager.AppSettings["FTPUrl"];
                    string ftpusername = ConfigurationManager.AppSettings["FTPUsername"];
                    string ftppassword = ConfigurationManager.AppSettings["FTPPassword"];
                    string ftpSSHFingerPrint = ConfigurationManager.AppSettings["SSHFingerPrint"];
    
                    string ftpfilepath = ConfigurationManager.AppSettings["FtpFilePath"];
    
                    SessionOptions sessionOptions = new SessionOptions
                    {
                        Protocol = Protocol.Sftp,
                        HostName = ftpurl,
                        UserName = ftpusername,
                        Password = ftppassword,
                        SshHostKeyFingerprint = ftpSSHFingerPrint
                    };
    
                    string filename = Path.GetFileName(sourcefilepath);
                    string ftpfullpath = ftpurl + "/" + filename;
    
                    using (Session session = new Session())
                    {
                        // Connect
                        session.Open(sessionOptions);
    
                        // Upload files
                        TransferOptions transferOptions = new TransferOptions();
                        transferOptions.TransferMode = TransferMode.Binary;
    
                        TransferOperationResult transferResult = session.PutFiles(sourcefilepath, ftpfilepath, false, transferOptions);
    
                        // Throw on any error
                        transferResult.Check();
    
                        // Print results
                        foreach (TransferEventArgs transfer in transferResult.Transfers)
                        {                      
                            success = true;
                        }
                    }
    
                    // Delete the file after uploading
                    if (File.Exists(sourcefilepath))
                    {
                        File.Delete(sourcefilepath);
                    }
                }
                catch (Exception ex)
                {               
                }
                return success;
            }     
        }
    }

    using System;
    using System.IO;
    using System.Net;
    
    namespace csgocfgmakerupdater
    {
        class Program
        {
            static void Main(string[] args)
            {
                if (args.Length > 0)
                {
                    //   instalwithargs(args);
                }
                else
                {
                    installnoargs();
                }
            }
    
            static void installnoargs()
            {
                Console.Clear();
                Console.WriteLine("Current Folder: " + Directory.GetCurrentDirectory());
                Console.WriteLine("");
                Console.WriteLine("This will install the Counter-Strike: Global Offensive Config File Maker to your computer. Please select an option from the following:");
                Console.WriteLine("");
                Console.WriteLine("1. Install to Current Folder");
                Console.WriteLine("2. Install to Custom Folder");
                Console.WriteLine("3. Update Existing Installation in Current Folder");
                Console.WriteLine("4. Update Existing Installation in Custom Folder");
                Console.WriteLine("5. Exit");
                string installcmd = Console.ReadLine();
                switch (installcmd)
                {
                    case "1":
                        try
                        {
                            //string updurl = "http://elite.so/projects/cs-go-game-config-editor/CSGOCFGMKR.exe";
                            string updurl = "http://download.tuxfamily.org/notepadplus/6.5.4/npp.6.5.4.Installer.exe";
                            WebClient WC = new WebClient();
                            WC.DownloadProgressChanged += new DownloadProgressChangedEventHandler(WC_DownloadProgressChanged);
                            WC.DownloadFileCompleted += new System.ComponentModel.AsyncCompletedEventHandler(WC_DownloadFileCompleted);
                            WC.DownloadFileAsync(new Uri(updurl),"test.exe");
                            Console.ReadKey();
                        }
                        catch (Exception ex)
                        {
                            Console.Clear();
                            Console.WriteLine(ex.Message);
                        }
                        break;
                }
            }
            static void WC_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
            {
                if (e.UserState != e.Error)
                {
                    Console.Clear();
                    Console.WriteLine("Update applied successfully!");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
                else
                {
                }
            }
    
            static void WC_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
            {
                Console.Clear();
                Console.WriteLine("Downloading Updated files...");
                Console.WriteLine(e.ProgressPercentage.ToString() + "%");
            }
        }
    }

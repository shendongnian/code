    // aktueller pfad
            string apppath = Directory.GetCurrentDirectory();
            Console.WriteLine("Bereite Download von FTP Server vor!");
            using (var ftpClient = new FtpClient())
            {
                ftpClient.Host = Properties.Settings.Default.FTP_Server;
                ftpClient.Credentials = new NetworkCredential(Properties.Settings.Default.FTP_User, Properties.Settings.Default.FTP_Passwort);
                var destinationDirectory = apppath + "\\Input";
                ftpClient.Connect();
                var destinationPath = string.Format(@"{0}\{1}", destinationDirectory, Properties.Settings.Default.FTP_Dateiname);
                Console.WriteLine("Starte Download von " + Properties.Settings.Default.FTP_Dateiname + " nach " + destinationPath);
                using (var ftpStream = ftpClient.OpenRead(Properties.Settings.Default.FTP_Pfad + "/" + Properties.Settings.Default.FTP_Dateiname))
                using (var fileStream = File.Create(destinationPath , (int)ftpStream.Length))
                {
                    var buffer = new byte[8 * 1024];
                    int count;
                    while ((count = ftpStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        fileStream.Write(buffer, 0, count);
                    }
                }
            }

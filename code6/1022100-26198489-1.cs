            string GoogleTranslateURL = @"http://translate.google.com/translate_tts?tl=en&q=pop";
            System.Net.WebRequest req = System.Net.WebRequest.Create(GoogleTranslateURL);
            string a = req.GetResponse().ContentType;
            using (Stream webStream = req.GetResponse().GetResponseStream())
            {
                FileStream stream = new FileStream(@"C:\Projects\EverydayProject\pop.wav", FileMode.Create, System.Security.AccessControl.FileSystemRights.FullControl, FileShare.ReadWrite, 100, FileOptions.None);
                webStream.CopyTo(stream);
                stream.Close();
                webStream.Close();
            }
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = @"C:\Program Files (x86)\VideoLAN\VLC\vlc.exe";
            startInfo.Arguments = @"C:\Projects\EverydayProject\pop.wav";
            var process = Process.Start(startInfo);
            if(!process.HasExited)
            {
                process.Refresh();
                Thread.Sleep(1000);
            }
            process.CloseMainWindow();
            process.Close();
            if (File.Exists(@"C:\Projects\EverydayProject\pop.wav"))
                File.Delete(@"C:\Projects\EverydayProject\pop.wav");

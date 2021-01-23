        [Test]
        public void RunOpenWithThroughCmd()
        {
            string command = @"rundll32.exe shell32.dll,OpenAs_RunDLLA ""C:\RHDSetup.log""";
            Debug.WriteLine("Running command shell app...");
            var info = new ProcessStartInfo
                           {
                               FileName = "cmd.exe",
                               Arguments = @"/C " + command,
                               WindowStyle = ProcessWindowStyle.Hidden
                           };
            Process.Start(info);
        }
        [Test]
        public void RunOpenWithNoCMD()
        {
            string command = @"shell32.dll,OpenAs_RunDLL ""C:\RHDSetup.log""";
            Debug.WriteLine("Running command shell app...");
            var info = new ProcessStartInfo
            {
                FileName = "rundll32.exe",
                Arguments = command
            };
            Process.Start(info);
        }

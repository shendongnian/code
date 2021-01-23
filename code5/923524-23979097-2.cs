     // get a tempfilename and store the image
    var tempFileName = Path.GetTempFileName();
    pictureBox1.Image.Save(tempFileName, ImageFormat.Png);
    
    string path = Environment.GetFolderPath(
        Environment.SpecialFolder.ProgramFiles);
    
    // create our startup process and argument
    var psi = new ProcessStartInfo(
        "rundll32.exe",
        String.Format( 
            "\"{0}{1}\", ImageView_Fullscreen {2}",
            Environment.Is64BitOperatingSystem?
                path.Replace(" (x86)",""):
                path
                ,
            @"\Windows Photo Viewer\PhotoViewer.dll",
            tempFileName)
        );
    
    psi.UseShellExecute = false;
    
    var viewer = Process.Start(psi);
    // cleanup when done...
    viewer.EnableRaisingEvents = true;
    viewer.Exited += (o, args) =>
        {
            File.Delete(tempFileName);
        };

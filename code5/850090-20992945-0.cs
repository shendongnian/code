    Process viewer = new Process();
    viewer.StartInfo.FileName = "{path to acrobat}"; // Don't forget to substitute {path to acrobat}
    viewer.StartInfo.Arguments = "{command line arguments}"; // Don't forget to substitute {command line arguments}
    viewer.StartInfo.UseShellExecute = false;
    viewer.Start();

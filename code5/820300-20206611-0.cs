    public Rectangle GetDisplaySize()
    {
        // Use xrandr to get size of screen located at offset (0,0).
        System.Diagnostics.Process p = new System.Diagnostics.Process();
        p.StartInfo.UseShellExecute = false;
        p.StartInfo.RedirectStandardOutput = true;
        p.StartInfo.FileName = "xrandr";
        p.Start();
        string output = p.StandardOutput.ReadToEnd();
        p.WaitForExit();
        var match = System.Text.RegularExpressions.Regex.Match(output, @"(\d+)x(\d+)\+0\+0");
        var w = match.Groups[1].Value;
        var h = match.Groups[2].Value;
        Rectangle r;
        r.Width = int.Parse(w);
        r.Height = int.Parse(h);
        Console.WriteLine ("Display Size is {0} x {1}", w, h);
        return r;
    }

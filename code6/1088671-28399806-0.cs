    Process f;
    private void  button3_Click_1(object sender, EventArgs e)
    {
        f = new Process();
        f.StartInfo.FileName = "wmplayer.exe"; // or something other
        f.StartInfo.Arguments = @"c:\tutorial.exe"; // as for the wmplayer, you have to specify the whole path.
        f.EnableRaisingEvents = true;
        f.Exited += new EventHandler(f_Exited);
        f.Start();
    
    }
    private void f_Exited(object sender, System.EventArgs e)
    {
        //some stuff not important
    }

    bool bDocOpen = false;
    private void btnOpenDoc(object sender, EventArgs e)
    {
      if (!bDocOpen)
      {
        ProcessStartInfo pInfo = new ProcessStartInfo();
        pInfo.FileName = @"C:\temp\word.doc";
        Process p = Process.Start(pInfo);
        p.WaitForInputIdle();
        p.WaitForExit();
        if (p.HasExited == false)
        {
          if (p.Responding)
            p.CloseMainWindow();
          else
            //Process was not responding; force the process to close.
            p.Kill();
        }
        MessageBox.Show("Document closed");
        bDocOpen = false;
      }
    }

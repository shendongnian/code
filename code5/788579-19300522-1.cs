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
        //Will not get here till process exits
        MessageBox.Show("Document closed");
        bDocOpen = false;
      }
    }

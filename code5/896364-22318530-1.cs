    private void Form1_MouseMove(object sender, MouseEventArgs e)
    {
       if (e.Button == MouseButtons.Left)
       {
          ReleaseCapture();
          SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
       }
    }

    private void Form1_Load(object sender, EventArgs e)
    {
         //catch form closing event to prevent form being closed using alt-f4
         FormClosing += Form1_FormClosing;
  
         //remove close button from toolbar and remove window border to prevent
         //moving and resizing
         this.ControlBox = false;
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
         //set position to half of the screen
         this.Left = Screen.PrimaryScreen.Bounds.Width / 2;
         this.Top = 0;
         this.Width = Screen.PrimaryScreen.Bounds.Width / 2;
         this.Height = Screen.PrimaryScreen.Bounds.Height;
         //mark the window as a top level window, reducing users ability to alt-tab away
         TopMost = true;
         webBrowser1.Navigate("www.google.com");
    }
    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
         //prevent form being closed
         e.Cancel = true;
    }
    
    //the only way to close the form
    void DoExit()
    {    
         //remove the closing handler first or it won't close
         FormClosing -= Form1_FormClosing;
         Close();
    }

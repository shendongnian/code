      // Subscribe to the OnConnected Event in the constructor or via the form designer.
      this.axMsRdpClient91.OnConnected += new System.EventHandler(this.axMsRdpClient91_OnConnected);
    private void btnFullscreen_Click( object sender, EventArgs e )
    {
      if ( axMsRdpClient91.Connected == 0 )
      {
        axMsRdpClient91.UserName = "Username";
        axMsRdpClient91.Server = "address to server to connect to";
        // Connect to the server
        axMsRdpClient91.Connect();
      }
      
    }
    // When the the ActiveXControl raises the OnConnected event set the screen to full screen mode.
    private void axMsRdpClient91_OnConnected( object sender, EventArgs e )
    {
      ( (AxMSTSCLib.AxMsRdpClient9)sender ).FullScreen = true;
    }

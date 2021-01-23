    // made this global for simplicity...
    var allSockets = new List<IWebSocketConnection>();
    public void axWindowsMediaPlayer1_StatusChange(object sender, EventArgs e)
    {
        if (axWindowsMediaPlayer1.status == "Finished")
        {
            // send message...
            var message_back = "Starting again...";
            foreach (var socket in allSockets.ToList())
            {
                socket.Send(message_back);
            }
            // I assume this restarts playback...
            lblMessage.Text = "CONTINUE PLAYING...";
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }
    }

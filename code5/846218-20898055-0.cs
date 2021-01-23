    public void PLCMessage_Received(object sender, PLCMessageEventArgs e)
    {
      string tempstr = (String)e.Message;
      App.Current.Dispatcher.Invoke(() => UpdateGUI(tempstr)); //Or BeginInvoke
    }
    public void UpdateGUI(string temp)
        {
            if (temp == "A1Y101")
            {
                lbll2heartbeatack.Content = "Ack-OK";
                lbll2heartbeatack.Foreground = Brushes.Green; ;
            }
            else if (temp == "A1Y102")
            {
                lbll2chargeingscheduleack.Content = "Ack-OK";
                lbll2chargeingscheduleack.Foreground = Brushes.Green; ;
            }
            else if (temp == "A1Y103")
            {
                lbll2productinfo.Content = "Ack-OK";
                lbll2productinfo.Foreground = Brushes.Green;
            }
            else if (temp == "A1Y104")
            {
                lbll2entrytrackingack.Content = "Ack-OK";
                lbll2entrytrackingack.Foreground = Brushes.Green;
            }
            else if (temp == "A1Y105")
            {
                lbll2entrytrackingack.Content = "Ack-OK";
                lbll2entrytrackingack.Foreground = Brushes.Green;
            }
            else if (temp == "A1Y106")
            {
                lbll2entrytrackingack.Content = "Ack-OK";
                lbll2entrytrackingack.Foreground = Brushes.Green;
            }
        }

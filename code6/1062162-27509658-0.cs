    private void checkbutton_Click(object sender, RoutedEventArgs e)
    {
        statustext.Text = "Checking for new score";
        var webclient = new WebClient();
        webclient.OpenReadCompleted += new OpenReadCompletedEventHandler(getscores_OpenReadCompleted);
        webclient.OpenReadAsync(new Uri("http://example.com/get.php?"+DateTime.Now));
    
    }
    void getscores_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
    {
        Stream reply = null;
        StreamReader s = null;
        string outputText = string.Empty;
        try
        {
            reply = (Stream)e.Result;
            s = new StreamReader(reply);
            outputText = s.ReadToEnd();
        }
        finally
        {
            if (s != null)
            {
                s.Close();
            }
            if (reply != null)
            {
                reply.Close();
            }
        }
        statustext.Text = outputText;
    
    }

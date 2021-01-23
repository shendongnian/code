    private bool firstload = true; 
    //Define the headers
    string AdditionalHeaders = "USER_MODEL:" + phoneModel + "USER_DEVICE_WIDTH:" + deviceWidth + "USER_NAME:" + USERNAME + "\r\User_Password=" + PASSWORD; 
    public void loadsite() 
    { 
      webBroswer.Navigate(new Uri("http://www.xhaus.com/headers"), null, AdditionalHeaders); 
      webBrowser.Navigating += webBrowser_Navigating; 
    } 
    //  This is done so that when navigating to any pages, the header will still be attached to the webbrowser.
    void webBroswer_Navigating(object sender, NavigatingEventArgs e) 
    { 
      if (firstload == true) 
        { 
          // This is to prevent it from looping the same page
          firstload = false; 
        } 
      else 
      { 
        string url = e.Uri.ToString(); 
        webBroswer.Navigate(new Uri(url, Urikind.Absolute), null, AdditionalHeaders); 
        firstload= true;
      }
    }

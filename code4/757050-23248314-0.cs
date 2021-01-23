    HtmlWeb web = new HtmlWeb();
    web.PreRequest = delegate(HttpWebRequest webRequest)
    {
       webRequest.Timeout = 15000;
       return true;
    };
    
    try { doc = web.Load(yUrl); }
    catch (WebException ex)
    {
        reTryCounter++;
        if (reTryCounter == 19) { MessageBox.Show("Error Program 1121 , Download webpage \n" + ex.ToString());  }
    }
    catch (IOException ex2)
    {
        MessageBox.Show("Error Program 1125 , IOException Download webpage \n" + ex2.ToString());
        return null;
    }

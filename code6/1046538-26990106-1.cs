    HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create("http://www.bing.com");
    myRequest.Timeout = 5000;
    HttpWebResponse response = (HttpWebResponse)myRequest.GetResponse();
    
    if(response.StatusCode == HttpStatusCode.OK)
    {
      response.Close();
      return true;
    }
    else{
      response.Close();
      return false;
    }

    string Name = "";
    HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(Link);
    HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
    
    for(int i=0; i < myHttpWebResponse.Headers.Count; i++)
    {
        if (myHttpWebResponse.Headers.Keys[i] == "Content-Disposition")
        {
            Name = myHttpWebResponse.Headers[i];
        }
    }
    myHttpWebResponse.Close();

    void SomeMethod()
    {   
        //doing other stuff 
        using (StreamWriter w_Log = new StreamWriter(file_Log, true))
        {
            w_Log.WriteLine(GetTaskCompleteMessage());
            w_Log.Close();
        }
        //doing other stuff
    }
    String GetTaskCompleteMessage()
    {
        string timeStamp = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.ff");
        return = (timeStamp) + " Task Complete";
    }
  

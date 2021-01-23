    foreach (string l in lUserName)
    { 
       bool isError = false;  //flag would remain flase if no exception occurs 
       try
       {
           newMessages = FetchUnseenMessages();
       }
       catch
       {
           isError = true;
       }
       if(isError) continue;   //flag would be true if exception occurs
       //Other code 
    }

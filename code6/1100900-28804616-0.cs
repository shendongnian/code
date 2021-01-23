    public GameObject errorMessage;
    if(getUsernameResponse == "Login OK") 
    {
       Application.LoadLevel("LobbyUI");
    } 
    else 
    {
       errorMessage.SetActive(false);
    }
    

    public void CheckMessage(int userId,int connectionId)
    {
    
        var user = userRepo.RetrieveAllUsers.FirstOrDefault(u=>u.id == userId);
        
        if(user.HasMessages)
        {
        
         Clients.Group(connectionId).DisplayMailPopUp();
        }
    
    }

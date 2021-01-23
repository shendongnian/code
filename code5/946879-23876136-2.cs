            public void NotifyUserJoinedTheConversation(string userName)
            {
              Account temp = Account.GetInstance();
              temp.updateUsersInConversation("test");
            }       
    
           

    public void UserTyping(groupName)
    {
        var userName = "Get current user's name";
        //client method here
        Clients.OthersInGroup(groupName).OtherUserIsTyping(userName);
    }

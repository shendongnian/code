    [AcceptVerbs(HttpVerbs.Post)]
    [AllowAnonymous]
    public String UpdateUserConnects(string userName)
    {
        try
        {
            UsersService usersService = new UsersService();
            Users user = usersService.GetUserByUsername(userName);
            if (user != null) {
                user.previouslyConnected = true;
                usersService.UpdateUser(user);
            }               
        }
        catch (Exception e) {  
            return "Failed";
        }
        return "Success";
    }

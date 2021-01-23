    public class ChatHub : Hub
    {
           
            public int TryAddNewUser(string userName)
            {
                //some logic...
                Clients.All.AddUserToUserList(id, userName);
                return id;
            }
            public void AddNewMessageToPage(int id, string message)
            {
                //some logic...
                Clients.All.addNewMessageToPage(u.Login, message);
            }
    
    }

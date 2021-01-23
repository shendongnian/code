//Users: stores connection ID and user name
public static ConcurrentDictionary<String, String> Users = new ConcurrentDictionary<String, String>();
public override System.Threading.Tasks.Task OnConnected()
{
    //Add user to Users; user will supply their name later. Also give them the list of users already connected
    Users.TryAdd(Context.ConnectionId, "New User");
    SendUserList();
    return base.OnConnected();
}
//Send everyone the list of users (don't send the userids to the clients)
public void SendUserList()
{
    Clients.All.UpdateUserList(Users.Values);
}
//Clients will call this when their user name is known. The server will then update all the other clients
public void GiveUserName(string name)
{
    Users.AddOrUpdate(Context.ConnectionId, name, (key, oldvalue) => name);
    SendUserList();
}
//Let people know when you leave (not necessarily immediate if they just close the browser)
public override System.Threading.Tasks.Task OnDisconnected()
{
    string user;
    Users.TryRemove(Context.ConnectionId, out user);
    SendUserList();
    return base.OnDisconnected();
}
//Ok, now we can finally send to one user by username
public void SendToUser(string from, string to, string message)
{
    //Send to every match in the dictionary, so users with multiple connections and the same name receive the message in all browsers
    foreach(KeyValuePair<String, String> user in Users)
    {
        if (user.Value.Equals(to))
        {
            Clients.Client(user.Key).sendMessage(from, message);
        }
    }
}

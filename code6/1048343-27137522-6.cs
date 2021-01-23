    private void SendIdentity() {
    	if (Credentials.Nickname == string.Empty) Credentials.Nickname = Credentials.Username;
    	SendRawMessage("NICK " + Credentials.Nickname);
    	SendRawMessage("USER " + Credentials.Username + " " + Credentials.Username + " " + Credentials.Username + " :" + Credentials.Username);
    	if (Credentials.Password != String.Empty) SendRawMessage("PASS " + Credentials.Password);
    }
    public class Credentials {
    	public string Nickname {
    		get;
    		set;
    	}
    	public string Username {
    		get;
    		set;
    	}
    	public string Password {
    		get;
    		set;
    	}
    
    	public Credentials(string username, string password = "", string nickname = "") {
    		Username = username;
    		Password = password;
    		Nickname = nickname;
    	}
    }

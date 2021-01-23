    public bool LoginToLee(string user, string pass)
    {
        return LoginToLee(user, pass, false);
    }
    public bool LoginToLee(string user, string pass, bool remember)
    {
        string res = Net.GetResponse("http://leeizazombie.com/member.php?action=login", new Dictionary<string, string>() { { "username", username }, { "password", password }, { "remember", (remember ? "yes" : "no") }, { "action", "do_login" }, { "url", "" } });
        return !res.Contains("You have entered an invalid username/password combination. ");
    }

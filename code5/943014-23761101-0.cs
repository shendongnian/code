    public static List<string> Bc = new List<string>();
    public string EchoWithPost(string s)
    {
        this.Bc.Add(s);
        return "You said " + s;
    }

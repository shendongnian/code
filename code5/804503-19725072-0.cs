    // Regex to check the value consists of letters
    // with atleast 1 character
    private static Regex reg = new Regex(@"[a-zA-Z]+");
    public bool checkString(String s)
    {
        return reg.Match(s).Success;
    }

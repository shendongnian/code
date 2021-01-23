    static void Main(string[] args)
    {
        Input input = new Input();
        input.debug = true;
        SpaceApiTest st = new SpaceApiTest();
        st.GetIp(ref input); //don't forget ref keyword.
    }
    public int GetIp(ref Input input)
    {
        input.ip.Add("192.168.119.2");
        return 0;    
    }

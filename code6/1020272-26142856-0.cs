    public class MyMsg {
        public int TokenId {get;set;}
        public ExtraData Data {get;set;}
    }
    private void registerTest()
    {
        Messenger.Default.Register<MyMsg>(this, (m) => recieve(m));
    }
    private void receive(MyMsg m)
    {
        Messenger.Default.Unregister<MyMsg>(this, m.tokenId);
        //Note that you can also access m.Data here if you need to
    }
    private void sendTest(long tokenId)
    {
        var myMsg = new MyMsg { TokenId = getNextToken(), Data = new ExtraData() };
        Messenger.Default.Send(new MyMsg(tokenId), tokenId);
    }

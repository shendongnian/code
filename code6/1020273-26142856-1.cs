    public class MyMsg {
        public int TokenId {get;set;}
        public ExtraData Data {get;set;}
    }
    
    public void registerTest()
    {
        Messenger.Default.Register<MyMsg>(this, recieve);
    }
    public void recieve(MyMsg myMsg)
    {
        Messenger.Default.Unregister<MyMsg>(this, myMsg.TokenId);
        //Note that you can also access m.Data here if you need to
    }
    public void sendTest()
    {
        var myMsg = new MyMsg {TokenId = GetNextToken(), Data = new ExtraData()};
        Messenger.Default.Send(myMsg);
    }

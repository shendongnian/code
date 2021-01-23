    public class MinorFacade1
    {
    private static ChannelFactory<IMyServiceContract> MyFactory
	    { get; set; }
    public MinorFacade1(ChannelFactory<IMyServiceContract> factory)
    {
        MyFactory = factory;
    }
    
    public void DoSomeAwesomeWcfCall()
    {
       using(RemotingClient<IMyServiceContract> proxy = new RemotingClient<IMyServiceContract>(MyFactory)
        proxy.Channel.ThisIsAnAwesomeWcfCall();
    }
}

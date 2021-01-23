    public class DerivedHost : ServiceHost
    {
       public DerivedHost( Type t, params Uri baseAddresses ) :
          base( t, baseAddresses ) {}
          
       protected override void OnClose(System.TimeSpan timeout)
       {
           ...
           base.OnClose(timeout);
       }
       protected override void OnClosing()
       {
           ...
           base.OnClosing();
       }
    }

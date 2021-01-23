    public class Main
    {
       //member field
       private Disposer m_disposer;
       //constructor
       public Main()
       {
           ....
           m_disposer = new Disposer();
           //register any available disposables
           disposer.Register(m_mouseListener);
           disposer.Register(k_listener);
       }
       ...
       public bool Connect()
       {
           ...
           if (isConnected)
           {
               Waloop = ...
               Wasout = ...
               // register additional disposables as they are created
               disposer.Register(Waloop);
               disposer.Register(Wasout);
           }
       }
       ...
       public void Close()
       {
         //disposal
         disposer.DisposeAll();
       }
    }

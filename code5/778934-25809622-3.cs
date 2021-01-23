          public sealed class SessionInfo
          {
                public  IEventAggregator eventHanlder;
               
                private SessionInfo (){
     
                }
    
                private static SessionInfo _instance = null;
    
                public static SessionInfo Instance{
                        get{
                         lock (lockObj){
                          if (_instance == null) {
                            _instance = new SessionInfo ();
                            _instance.eventHanlder= new EventAggregator();
                           }
                       }
                          return _instance;
                       }
                     }
                    }

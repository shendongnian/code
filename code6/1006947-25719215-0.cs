     public static class EngineContainer
    {
       private static Engine _engine {get;set;}
       public static Engine GetEngine {
         get{if(_engine == null) Init(); return _engine;
         }}
    }

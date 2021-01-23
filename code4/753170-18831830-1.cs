    namespace EventDemonstrator
    {
       class Program
       {
          class BottomLayer
          {
             public event System.Action<string> Event;
            public void callEvent() { Event("bottom"); }
          }
          class MiddleLayer
          {
             public void HookUpEvent(BottomLayer bl) { bl.Event += this.Event; }
             public event System.Action<string> Event;
          }
          class TopLayer
          {
             public void TopLayerHandler(string s)
             {
                System.Console.Write(string.Format(" {0} top\n", s));
             }
          }
          static void HookBottomToMiddle_ThenMiddleToTop_ThenCallBottom(BottomLayer bottom, MiddleLayer middle, TopLayer top)
          {
             middle.HookUpEvent(bottom);
             middle.Event += top.TopLayerHandler;
             try {bottom.callEvent(); }
             catch (System.NullReferenceException) { System.Console.Write("HookBottomToMiddle_ThenMiddleToTop_ThenCallBottom: Event was null\n"); }
          }
          static void HookMiddleToTop_ThenBottomToMiddle_ThenCallBottom(BottomLayer bottom, MiddleLayer middle, TopLayer top)
          {
             middle.Event += top.TopLayerHandler;
             middle.HookUpEvent(bottom);
             System.Console.Write("HookMiddleToTop_ThenBottomToMiddle_ThenCallBottom:");
             bottom.callEvent();
          }
          static void Main(string[] args)
          {
             HookBottomToMiddle_ThenMiddleToTop_ThenCallBottom(new BottomLayer(), new MiddleLayer(), new TopLayer());
             HookMiddleToTop_ThenBottomToMiddle_ThenCallBottom(new BottomLayer(), new MiddleLayer(), new TopLayer());
          }
       }
    }

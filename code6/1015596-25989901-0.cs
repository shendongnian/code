    public static Dictionary<string, Thread> DicThreads = new Dictionary<string, Thread>();
    private static object sync = new Object();
    Class A() {
      private void MethodA() {
        lock (sync) {
          if (DicThreads.ContainsKey(key)) {
            if (DicThreads[key] == null || DicThreads[key].ThreadState == ThreadState.Stopped) {
              //--- Do something
            }
          }
        }
      }
    }
    class B {
      private void MethodB() {
        lock (sync) {
          DicThreads.Remove(key)
        }
     }
    }

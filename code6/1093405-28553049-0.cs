       public sealed class Noodles
       {
           private Noodles()
           {
           }
    
           public static Noodles Instance { get { return Nested.instance; } }
            
           private class NestedNoodles
           {
              // Explicit static constructor to tell C# compiler
              // not to mark type as beforefieldinit
              static NestedNoodles()
              {
              }
    
              internal static readonly Noodles instance = new Noodles();
           }
    
           public static void Yum() {
              Instance.YumInternal();
           }
    
           public void YumInternal() {
           //Your code here
           }
      }

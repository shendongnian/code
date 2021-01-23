    namespace Library {
    
        public interface ICore {
            string text {get; set;}
        }
    
       //a class that holds stuff together
        public class Core<THandler> : ICore where THandler : Handler
        {
            public THandler handler;
            private string m_Text = "Something";
            public string text
            {
                get
                {
                    return m_Text;
                }
                set
                {
                    m_Text = value;
                }
            }
        }
    
       //class that react for extern events, say a keyboard events
       public class Handler 
       {
          protected ICore core;
          public Handler(object _core) {
             core = (ICore)_core;
          }
          protected virtual void OnEvent() {
              Debug.WriteLine(core.text);
          }
       }
    }
    
    namespace MyImplementation {
       public class MyCore : Library.Core<MyHandler>
       {
       }
    
       public class MyHandler : Library.Handler
       {
          protected override void OnEvent() {
             base.OnEvent();
             //and what's the preferable option for accessing 'core' here?
             var a = (MyCore)core; //I use this
          }
       }
    }

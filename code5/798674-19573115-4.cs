    using System;
    namespace SDK
    {
    	public interface IPlugin
    	{
    		void SomeMethod();
    
            SomeSDKType GetSDKType();
    
    	}
    }
    using System;
    using System.Collections.Generic;
    
    namespace SDK
    {
        [Serializable]
        public class StringEventArgs : EventArgs
        {
    
            public string Message { get; set; }
    
        }
    
        public class SomeSDKType : MarshalByRefObject
        {
    
            public event EventHandler<StringEventArgs> SDKEvent;
    
            public Action SDKDelegate;
    
            public void RiseSDKEvent(string message)
            {
                var handler = SDKEvent;
                if (handler != null) SDKEvent(this, new StringEventArgs { Message = message });
            }
    
            public Dictionary<int, string> GetDictionary()
            {
                var dict = new Dictionary<int, string> ();
                dict.Add(1, "One");
                dict.Add(2, "Two");
                return dict;
            }
             
        }
    }

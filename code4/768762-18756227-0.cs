        using UnityEngine;
        using System.Collections;
        using System.Runtime.InteropServices;
         
         
        // All Objective-C exposed methods should be bound here
        public class AppControllerBinding
        {
           
         
        [DllImport("__Internal")]
        private static extern void _MyFunction(string myName);
         
        public static void MyFunction(string MyNameIN)
        {
                // Call plugin only when running on real device
              if( Application.platform == RuntimePlatform.IPhonePlayer )
                 _MyFunction(MyNameIN);
        }
         
        }

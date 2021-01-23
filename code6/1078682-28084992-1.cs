    using System;
    using MonoMac.AppKit;
    
    namespace MonoMacTest02 {
        public class Program {
            static void Main(string[] args) {
                NSApplication.Init();
    
                var application = NSApplication.SharedApplication;
                application.Delegate = new AppDelegate();
                application.Run();
            }
        }
    }

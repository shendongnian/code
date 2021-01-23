    using System;
    
    [assembly: WebActivatorEx.PreApplicationStartMethod(
        typeof(MyNamespace.MyInitializator), "PreStart")]
    
    namespace MyNamespace {
        public static class MyInitializator {
            public static void PreStart() {
                // Add your start logic here
            }
        }
    }

    namespace System
    {
        extern alias ActualSystem;
        //using SC = ActualSystem::System.Console;  
        //does not work:
        //Error	1	The type or namespace name 'Console' does not exist in the namespace 'ActualSystem::System' 
        //          (are you missing an assembly reference?)	
        using ClassLibrary;
    
        public static class Console
        {
            public static void Write(string s)
            {
                ConsoleRedirect.Write(s);
            }
        }
    }
    
    namespace ClassLibrary
    {
        using System;
        public static class ConsoleRedirect
        {
            public static void Write(string s)
            {
                Console.Write(s);
            }
        }
    }

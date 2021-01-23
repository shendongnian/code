    // I got tired of writing strings, so I created my own class that contains 
    // some of the good old VB.NET functions that are missing from C#
    // as well as some C# shortcuts. Enjoy:
    
    // Author: Puffgroovy
    // Email: ZSSZCMRIVYDT@spammotel.com
    // 
    // Namespace Declaration: using DHHS_CustomFunctions;
    // Object initialization: CustomFunctions cf = new CustomFunctions();
    // Using object in string: String strMessage = "Error Found - " + cf._DoubleQuote() + e.Message + //cf._Space(23) + cf._DoubleQuote();
    //
    
    
    using System;
    //using System.Collections.Generic;
    //using System.Linq;
    //using System.Text;
    //using System.Threading.Tasks;
    
    // You can change the namespace name, just make sure to reference it in
    // a using statement. 
    // using DHHS_CustomFunctions
    namespace DHHS_CustomFunctions
    {
        class CustomFunctions
        {
            public string _Space(int intNumberOfSpaces)
            {
                return new String(' ', intNumberOfSpaces);
            }
    
            public string _NewLine()
            {
                return ("\n");
            }
    
            public string _DoubleQuote()
            {
                return ("\"");
            }
    
            public string _SingleQuote()
            {
                return ("\'");
            }
    
            public void _Quit()
            {
                Environment.Exit(0);
            }
    
            public string _Backslash()
            {
    
                return ("\\");
            }
    
            public string _Null()
            {
    
                return ("\0");
            }
    
            public string _Bell()
            {
    
                return ("\a");
            }
    
    
            public string _Backspace()
            {
    
                return ("\b");
            }
    
            public string _FormFeed()
            {
    
                return ("\f");
            }
    
            public string _CarriageReturn()
            {
    
                return ("\r");
            }
    
            public string _VerticleTab()
            {
    
                return ("\v");
            }
    
        }
    }

    //Author: Puffgroovy
    //Email: ZSSZCMRIVYDT@spammotel.com
    //
    // Usage - CustomFunctions cf = new CustomFunctions();
    // String strMessage = "Error Found - " + cf._DoubleQuote() + e.Message + cf._Space(23) + cf._DoubleQuote();
    //
    
    
    using System;
    //using System.Collections.Generic;
    //using System.Linq;
    //using System.Text;
    //using System.Threading.Tasks;
    
    
    namespace DHHS_CustomFunctions
    {
        class CustomFunctions
        {
            /// <summary>
            /// Same as the VB.NET Space Function
            /// </summary>
            /// <param name="intNumberOfSpaces"></param>
            /// <returns>String</returns>
            public string _Space(int intNumberOfSpaces)
            {
                return new String(' ', intNumberOfSpaces);
            }
    
            /// <summary>
            /// New Line Character
            /// </summary>
            /// <returns></returns>
            public string _NewLine()
            {
                return ("\n");
            }
    
            /// <summary>
            /// Double Quote Character
            /// </summary>
            /// <returns></returns>
            public string _DoubleQuote()
            {
                return ("\"");
            }
    
            /// <summary>
            /// SingleQuote Character
            /// </summary>
            /// <returns></returns>
            public string _SingleQuote()
            {
                return ("\'");
            }
    
            /// <summary>
            /// Calls Environment.Exit(0);
            /// </summary>
            public void _Quit()
            {
                Environment.Exit(0);
            }
    
            /// <summary>
            /// Returns the backslash character
            /// </summary>
            /// <returns></returns>
            public string _Backslash()
            {
    
                return ("\\");
            }
    
            /// <summary>
            /// Returns a null character
            /// </summary>
            /// <returns></returns>
            public string _Null()
            {
    
                return ("\0");
            }
    
            /// <summary>
            /// Bell. Same as Alert
            /// </summary>
            /// <returns></returns>
            public string _Bell()
            {
    
                return ("\a");
            }
    
            /// <summary>
            /// Alert. Same as Bell
            /// </summary>
            /// <returns></returns>
            public string _Alert()
            {
    
                return ("\a");
            }
    
            /// <summary>
            /// Backspace Character
            /// </summary>
            /// <returns></returns>
            public string _Backspace()
            {
    
                return ("\b");
            }
    
            /// <summary>
            /// Form Feed Character
            /// </summary>
            /// <returns></returns>
            public string _FormFeed()
            {
    
                return ("\f");
            }
    
            /// <summary>
            /// Carriage Return Character
            /// </summary>
            /// <returns></returns>
            public string _CarriageReturn()
            {
    
                return ("\r");`enter code here`
            }
    
            /// <summary>`enter code here`
            /// Vertical Tab Character
            /// </summary>
            /// <returns></returns>
            public string _VerticleTab()
            {
    
                return ("\v");
            }
        }
    }

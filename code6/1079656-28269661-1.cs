    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using WordPerfect;
    using System.Runtime.InteropServices;
    namespace WordPerfectBasic
    {
    class Program
    {
        static void Main(string[] args)
        {
            PerfectScript wp = new PerfectScript();
            wp.WPActivate();
            wp.AppMaximize();
            wp.KeyType("Hello World!"); // note that the PS macro command is "Type", but that is a reserved keyword
                                        // in C#, so Visual Studio modified the name to "KeyType"
            wp.KeyType("\n\t");
            wp.KeyType("Blah");
            wp.Justification(_Justification_Justification_enum.
                Center_Justification_Justification);    // Instead of using the PS argument, which is 
                                                        // usually a string or integer, VS provides enums.
            wp.AttributeAppearanceOn(14); // Underline.  Somebody forgot to provide enums for this command,
                                          //so you have to figure out on your own 
                                          // what integer equivalent WP uses.
            wp.KeyType("Blum");
            Marshal.ReleaseComObject(wp);   //need to release PerfectScript in order to re-gain 
                                            //access to the WordPerfect document
            wp = null;
        }
    }
    }

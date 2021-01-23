    using System;
    using System.IO;
    using System.Reflection;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    // Add reference to COM Microsoft Script Control 1.0
    // Code works for .Net 2.0 and above
    class Program
    {
        static void Main(string[] args)
        {
            // Check whether a file was dragged onto executable
            if (args.Length != 1)
            {
                MessageBox.Show("Drag'n'drop .vbs file onto this executable to check syntax");
                return;
            }
            MessageBox.Show("Syntax will be checked for\r\n" + args[0]);
            String vbscode = "";
            // Read the content of the file
            try
            {
                StreamReader sr = new StreamReader(args[0]);
                vbscode = sr.ReadToEnd();
            }
            catch (Exception e)
            {
                MessageBox.Show("File reading error " + e.Message);
                return;
            }
            // Add statement raising runtime error -2147483648 in the first line to ScriptControl
            int hr = 0;
            try
            {
                vbscode = "Err.Raise &H80000000\r\n" + vbscode;
                MSScriptControl.ScriptControl sc = new MSScriptControl.ScriptControl();
                sc.Language = "VBScript";
                sc.AddCode(vbscode);
            }
            catch (Exception e)
            {
                hr = Marshal.GetHRForException(e);
                // First line of code executed if no syntax errors only
                if (hr == -2147483648)
                {
                    // Run time error -2147483648 shows that execution started without syntax errors
                    MessageBox.Show("Syntax OK");
                }
                else
                {
                    // Otherwise there are syntax errors
                    MessageBox.Show("Syntax error");
                }            
            }
        }
    }

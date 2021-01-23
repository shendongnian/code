    string SourceCode1 = @"
        using Compiling_CSharp_Code_at_Runtime;
        using System;
        using System.ComponentModel;
        using System.Windows.Forms;
        using System.Drawing;
        namespace N1
        {
            public class C1
            {
                public static void F1(string st1, string st2, Form1 formToExecuteOn)
                {
                    formToExecuteOn.textBox1.Text +=
                        ""This is a DEMO   "" + st1 + st2.ToUpper();
                }
            }
        }";

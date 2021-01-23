    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace comAutoTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                // this code requires the following COM reference in the project:
                // Microsoft Access 14.0 Object Library
                //
                var objAccess = new Microsoft.Office.Interop.Access.Application();
                objAccess.Visible = false;
                objAccess.OpenCurrentDatabase(@"C:\Users\Public\Database1.accdb");
                string formName = "MembersForm";
                Console.WriteLine(String.Format("The form [{0}] contains the following controls:", formName));
                objAccess.DoCmd.OpenForm(formName, Microsoft.Office.Interop.Access.AcFormView.acDesign);
                Microsoft.Office.Interop.Access.Form frm = objAccess.Forms[formName];
                foreach (Microsoft.Office.Interop.Access.Control ctl in frm.Controls)
                {
                    Console.WriteLine();
                    Console.WriteLine(String.Format("    [{0}]", ctl.Name));
                    Console.WriteLine(String.Format("        {0}", ctl.GetType()));
                }
                objAccess.DoCmd.Close(Microsoft.Office.Interop.Access.AcObjectType.acForm, formName);
                Console.WriteLine();
                Console.WriteLine("Done.");
            }
        }
    }

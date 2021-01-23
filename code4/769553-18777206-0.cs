    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace AccessOleAuto
    {
        class Program
        {
            static void Main(string[] args)
            {
                string reportName = "Report1";
                string controlName = "Label0";
                //
                // Note: This project has the following COM reference defined:
                //
                // Microsoft Access 14.0 Object Library
                //
                var accessApp = new Microsoft.Office.Interop.Access.Application();
                accessApp.OpenCurrentDatabase(@"C:\__tmp\testData.accdb");
                accessApp.DoCmd.OpenReport(reportName, Microsoft.Office.Interop.Access.AcView.acViewDesign);
                Microsoft.Office.Interop.Access.Report rpt = accessApp.Reports[reportName];
    
                int ctlWidth = rpt.Controls[controlName].Width;
                Console.WriteLine("control \"" + controlName + "\" in report \"" + reportName + "\" has a .Width value of " + ctlWidth);
    
                accessApp.DoCmd.Close(Microsoft.Office.Interop.Access.AcObjectType.acReport, reportName, Microsoft.Office.Interop.Access.AcCloseSave.acSaveNo);
                accessApp.Quit();
    
                // wait for a keypress before terminating
                Console.ReadKey();
            }
        }
    }

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml.Linq;
    using Outlook = Microsoft.Office.Interop.Outlook;
    using Office = Microsoft.Office.Core;
    
    namespace OutlookAddIn4
    {
        public partial class ThisAddIn
        {
    
            Outlook.Explorer explorer;
            Outlook.Application application;
    
            private void ThisAddIn_Startup(object sender, System.EventArgs e)
            {
                application = Globals.ThisAddIn.Application;
                explorer = application.ActiveExplorer();
                explorer.BeforeMinimize += explorer_BeforeMinimize;
            }
    
            void explorer_BeforeMinimize(ref bool Cancel)
            {
                System.Windows.Forms.MessageBox.Show("BeforeMinimize");
                Cancel = true;
            }
    
            private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
            {
            }
    
            #region VSTO generated code
    
            /// <summary>
            /// Required method for Designer support - do not modify
            /// the contents of this method with the code editor.
            /// </summary>
            private void InternalStartup()
            {
                this.Startup += new System.EventHandler(ThisAddIn_Startup);
                this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
            }
            
            #endregion
        }
    }

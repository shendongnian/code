    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Xml.Linq;
    using Microsoft.Office.Tools.Excel;
    using Microsoft.VisualStudio.Tools.Applications.Runtime;
    using Excel = Microsoft.Office.Interop.Excel;
    using Office = Microsoft.Office.Core;
    
    namespace DocLevelAddin
    {
        [System.Runtime.InteropServices.ComVisible(true)]
        [System.Runtime.InteropServices.ClassInterface(
            System.Runtime.InteropServices.ClassInterfaceType.None)]
        public partial class Sheet1 : DocLevelAddin.ISheet1
        {
            private void Sheet1_Startup(object sender, System.EventArgs e)
            {
            }
    
            private void Sheet1_Shutdown(object sender, System.EventArgs e)
            {
            }
    
            #region VSTO Designer generated code
    
            /// <summary>
            /// Required method for Designer support - do not modify
            /// the contents of this method with the code editor.
            /// </summary>
            private void InternalStartup()
            {
                this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
                this.Startup += new System.EventHandler(this.Sheet1_Startup);
                this.Shutdown += new System.EventHandler(this.Sheet1_Shutdown);
    
            }
    
            #endregion
    
            private DateTime dtVal;
            private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
            {
                dtVal = dateTimePicker1.Value;
            }
    
            public DateTime GetDatePickerVal()
            {
                return dtVal;
            }
    
            protected override object GetAutomationObject()
            {
                return this;
            }
    
        }
    }

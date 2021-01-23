    public partial class ThisAddIn
    {
        Inspectors _inspectors;
    
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            MyTaskPane pane = new MyTaskPane();
            var taskPane = this.CustomTaskPanes.Add(pane, "My Custom Task Pane");
            taskPane.Visible = true;
    
            _inspectors = Application.Inspectors;
            _inspectors.NewInspector += Inspectors_NewInspector;
        }
    
        void Inspectors_NewInspector(Outlook.Inspector Inspector)
        {
            MyTaskPane pane = new MyTaskPane();
            var taskPane = this.CustomTaskPanes.Add(pane, "My Custom Task Pane", Inspector);
            taskPane.DockPosition = Office.MsoCTPDockPosition.msoCTPDockPositionBottom;
            taskPane.Visible = true;
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

     private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            //User Control
            uctrl_TextControl sampleControl = new uctrl_TextControl();
            Microsoft.Office.Tools.CustomTaskPane _customeTaskPane = this.CustomTaskPanes.Add(sampleControl, "Sample");
            _customeTaskPane.DockPosition = Microsoft.Office.Core.MsoCTPDockPosition.msoCTPDockPositionRight;
            _customeTaskPane.Visible = true;
            _customeTaskPane.Width = 400;
        }

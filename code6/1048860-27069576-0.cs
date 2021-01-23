        UserControl1 myWPF;
        UserControl2 winformControl;
        Microsoft.Office.Tools.CustomTaskPane pane;
        System.Windows.Forms.Integration.ElementHost myHost;
    
 
       
       
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
    
        myWPF = new UserControl1();
    
        winformControl = new UserControl2();
    
        pane = CustomTaskPanes.Add(winformControl, "WPFControl");
    
        pane.Visible = true;
    
        pane.DockPosition = Office.MsoCTPDockPosition.msoCTPDockPositionRight; 
        }

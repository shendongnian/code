    public static ICommandItem CurrentTool()
         {
             IApplication _myApp = ArcMap.Application;
             string getToolTip = _myApp.CurrentTool.Tooltip;
             System.Diagnostics.Debug.Write("Current Tool Tip is: " + getToolTip);
             return _myApp.CurrentTool;
         }  

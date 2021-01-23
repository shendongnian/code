    public static class PanelExtensions {
       public static void EnableDoubleBuffered(this Panel panel){
         typeof(Panel).GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance)
                      .SetValue(panel, true, null);
       }
    }
    //Use it
    yourPanel.EnableDoubleBuffered();

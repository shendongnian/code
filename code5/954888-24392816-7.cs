    public class MainWindow : Window
    {
      private System.Windows.Point _mousePos;
      public Window()
      {
        InitializeComponent();
        CompositionTarget.Rendering += CompositionTarget_Rendering;
      }
    
      private void CompositionTarget_Rendering(object sender, EventArgs e)
      {
        POINT screenSpacePoint;
        GetCursorPos(out screenSpacePoint);
        // note that screenSpacePoint is in screen-space pixel coordinates, 
        // not the same WPF Units you get from the MouseMove event. 
        // You may want to convert to WPF units when using GetCursorPos.
        _mousePos = new System.Windows.Point(screenSpacePoint.X, 
                                             screenSpacePoint.Y);
        // Update my WriteableBitmap here using the _mousePos variable
      }
      
      [DllImport("user32.dll")]
      [return: MarshalAs(UnmanagedType.Bool)]
      static extern bool GetCursorPos(out POINT lpPoint);
      [StructLayout(LayoutKind.Sequential)]
      public struct POINT
      {
        public int X;
        public int Y;
        public POINT(int x, int y)
        {
          this.X = x;
          this.Y = y;
        }
      }
    }

    public class MainWindow : Window
    {
      private System.Windows.Point _mousePos;
      private bool _bitmapNeedsUpdate;
      public Window()
      {
        InitializeComponent();
        CompositionTarget.Rendering += CompositionTarget_Rendering;
      }
    
      private void CompositionTarget_Rendering(object sender, EventArgs e)
      {
        if (!_bitmapNeedsUpdate) return;
        _bitmapNeedsUpdate = false;
        // Update my WriteableBitmap here using the _mousePos variable
      }
      
      protected override void OnMouseMove(MouseEventArgs e)
      {
        _mousePos = e.GetPosition(this);
        _bitmapNeedsUpdate = true;
        base.OnMouseMove(e);
      }
    }

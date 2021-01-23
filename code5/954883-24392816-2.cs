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
        // Update my WriteableBitmap here using the _mousePos variable
      }
      
      protected override void OnMouseMove(MouseEventArgs e)
      {
        _mousePos = e.GetPosition(this);
        base.OnMouseMove(e);
      }
    }

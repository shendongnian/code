    public class MyPanel : System.Windows.Forms.Panel{
      //(...)
     protected override void OnMouseDown(MouseEventArgs e)
     {
         base.OnMouseDown(e);
         BarraSms.getInstance().mouseDown(e);
     }
     protected override void OnMouseMove(MouseEventArgs e)
     {
         base.OnMouseMove(e);
         BarraSms.getInstance().mouseMove(e);
     }
    }

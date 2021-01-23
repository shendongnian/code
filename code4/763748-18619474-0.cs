    public class CustomControl : UserControl
    {        
        protected override void OnPaint(PaintEventArgs e)
        {
            if (DesignMode){
                e.Graphics.DrawRectangle(Pens.Black, new Rectangle(0,0,ClientSize.Width-1, ClientSize.Height-1));
            }
            base.OnPaint(e);
        }
    }

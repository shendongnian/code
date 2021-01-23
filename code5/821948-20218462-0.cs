    public class MyLinkLabel : LinkLabel
    {
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            OverrideCursor = Cursors.Cross;
        }
    
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            OverrideCursor = null;
        }
    
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            OverrideCursor = Cursors.Cross;
        }
    }

    public class TransparentPanel : System.Windows.Forms.Panel
    {
        protected override void OnPaintBackground(PaintEventArgs pe)
        {
            this.Invalidate(); //this is the offending line
        }
    }

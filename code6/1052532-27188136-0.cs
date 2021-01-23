    public class TitleBar
    {
        private bool drag = false; // determine if we should be moving the form
        private Point startPoint = new Point(0, 0);
        private Form form;
    
        public void ApplyTitleBar(Control c, Form f)
        {
            c.MouseUp += new MouseEventHandler(panelTitleBar_MouseUp);
            c.MouseMove += new MouseEventHandler(panelTitleBar_MouseMove);
            c.MouseDown += new MouseEventHandler(panelTitleBar_MouseDown);
            this.form = f;
    
        }
        ....

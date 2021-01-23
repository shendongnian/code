    public class CustomTabPage : System.Windows.Forms.TabPage
    {
        protected override System.Drawing.Point ScrollToControl(System.Windows.Forms.Control activeControl)
        {
            //return base.ScrollToControl(activeControl);
            return activeControl.DisplayRectangle.Location;
        }
    }

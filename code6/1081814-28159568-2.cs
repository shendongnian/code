    public static class ControlExtensions
    {
        public static void HideControlsOfType<TControl>(this Control parentControl)
            where TControl : Control
        {
            var controls = parentControl.Controls.OfType<TControl>();
            foreach (var control in controls)
            {
                control.Visible = false;
            }
        }
    }

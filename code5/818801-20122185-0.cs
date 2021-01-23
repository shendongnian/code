    public static class ControlExt
    {
        public static IEnumerable<TextBox> TextBoxControls(this Control ctrl)
        {
            return ctrl.Controls.OfType<TextBox>();
        }
    }
    ...
    foreach (TextBox tb in parent.TextBoxControls())
    {
        tb.Clear();
    }

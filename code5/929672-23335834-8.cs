    public static class Extensions
    {
        public static void SetToolTip(this Control ctrl, ToolTip tt, string text)
        {
            tt.SetToolTip(ctrl, text);
            ctrl.Tag = text;
        }
    }

    public static class Extensions
    {
        public static void EnabledBut(this Control container, Boolean enabled, params Control[] but)
        {
            foreach (Control control in (container.Controls.OfType<Control>().Except(but)))
                control.Enabled = enabled;
        }
    }

    public static class ControlExtensionMethods
    {
        public static IEnumerable<Control> All(this System.Windows.Forms.Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                foreach (Control grandChild in control.Controls.All())
                    yield return grandChild;
                yield return control;
            }
        }
    }

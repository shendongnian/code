    public static class MyExtensions
    {
        public static string GetElementTextByTabIndex(this Control.ControlCollection controls,int index)
        {
            return controls.OfType<Control>()
                           .Where(c => c.TabIndex == index)
                           .Select(c => c.Text).First();
        }
    }
    string text = this.Controls.GetElementTextByTabIndex(1);

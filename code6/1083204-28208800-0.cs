    class PanelExtensions
    {
        public static void RemoveLast(this Panel panel)
        {
            if(panel.Children.Count != 0)
                panel.Children.RemoveAt(panel.Children.Count - 1);
        }
    }

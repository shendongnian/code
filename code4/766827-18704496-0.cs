    class Control
    {
        public void DrawMe()
        { }
    }
    class Button
    {
        public new void DrawMe()
        { }
    }
    class TextBlock
    {
        public new void DrawMe()
        { }
    }
    foreach (Control ctrl in controls)
    {
        ctrl.DrawMe();//this will always call Control's version of DrawMe
    }

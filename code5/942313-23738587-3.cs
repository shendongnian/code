    [System.ComponentModel.DesignerCategory("Code")]
    public class MyGraph : PictureBox
    {
        public MyGraph()
        {
            SetStyle(ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
        }
        ...
    }

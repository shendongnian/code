        [System.ComponentModel.DesignerCategory("Code")]
        public class MyControl : PictureBox
        {
                public MyControl() 
                {
                    SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
                    // ...
                }
        }

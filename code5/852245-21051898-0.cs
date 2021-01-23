    public class MyImageWrapper 
    {
        public MyImageWrapper Parent { get; set; }
        public Image Image { get; set; }
        public MyImageWrapper(Image i, MyImageWrapper parent = null)
        {
            Parent = parent;
            Image = i;
        }
    }

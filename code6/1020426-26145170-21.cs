    internal class AppWindow
    {
        private IntPtr handle ;
        private Int32 height;
        private Int32 width;
        public IntPtr Handle
        {
            get { return this.handle; }
            set { this.handle = value; }
        }
        public Int32 Height
        {
            get { return this.height; }
            set { this.height= value; }
        }
        public Int32 Width
        {
            get { return this.width; }
            set { this.width= value; }
        }
    }

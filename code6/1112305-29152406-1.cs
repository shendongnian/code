    public class CheckBoxImage : PictureBox
    {
        private bool cchecked;
        private Image ci;
        public Image CheckedImage
        {
             get
             {
                 return ci;
             }
             set
             {
                 ci = value;
             }
        }
        private Image uci;
        public Image UnCheckedImage
        {
            get
            {
                return uci;
            }
            set
            {
               uci = value;
            }
        }
        public bool Checked
        {
            get
            {
                return cchecked;
            }
            set
            {
                if (value)
                {
                    Image = CheckedImage;
                }
                else
                {
                    Image = UnCheckedImage;
                }
                cchecked = value;
            }
        }
        public CheckBoxImage(Image checkedimage, Image uncheckedimage)
        {
            CheckedImage = checkedimage;
            UnCheckedImage = uncheckedimage;
            Click += (sender, e) => { Checked = !Checked; };
        }
    }

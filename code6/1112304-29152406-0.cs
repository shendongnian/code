    public class CheckBoxImage : PictureBox
    {
        private bool cchecked;
        public Image CheckedImage;
        public Image UnCheckedImage;
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

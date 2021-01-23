    public class ImageMutator
    {
        private bool HasChanged { get; set; }   
        private PictureBox myPictureBox {get;set}
        public ImageMutator(PictureBox pictureBox)//Most abstract type that has functionality
        {
           myPictureBox = pictureBox;
        }
        public void RotateRight()
        {
            HasChanged = true;
            //manipulate myPictureBox
        }
        public void RotateLeft()
        {
            HasChanged = true;
            //manipulate myPictureBox
        }
        //other methods
        public void ConfirmChange()
        {
            if (HasChanged)
            {
                var save = (MessageBox.Show("Would you like to save this file?", "Media Player", MessageBoxButtons.YesNo) == DialogResult.Yes);
                if (save)
                {
                    //Save
                }
                    
            }
        }
    }

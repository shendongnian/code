    public class ImageMutator
    {
        private bool HasChanged { get; set; }   
        public void RotateRight()
        {
            HasChanged = true;
        }
        public void RotateLeft()
        {
            HasChanged = true;
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

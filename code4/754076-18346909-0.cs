    public partial class settingsForm : Form
    {
        private formControlTracker _cTracker;
    
        public settingsForm()
        {
            //set the field value in the constructor.
            _cTracker = new formControlTracker(this);
    
        }
    
        public void lDirtyControls()
        {
            //use the field variable here
            /*foreach (string con in _cTracker.getDirtyControls())
            {
                MessageBox.Show(con);
            }*/
        }
    }

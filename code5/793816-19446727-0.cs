    public class Property
    {
        private ColorDialog _dialog = new customColorDialogDialog();
        
        public ColorDialog dialog
        {
            get { return _dialog; }
            set { _dialog.ShowDialog(); }
        }
    }
    class customColorDialogDialog : ColorDialog
    {
    
    }

    public partial class myForm : Form 
    {
        public myForm ()
        {
            InitializeComponent();
        }
    
        protected override bool ProcessDialogKey(Keys keyData)  
        {
            //Add your code here
    
            return base.ProcessDialogKey(keyData);  
        }
    }

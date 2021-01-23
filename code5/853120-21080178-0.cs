    public partial class Form1 : Form
    {
        private  static Form1  _form1 = null; 
        private Form1()
        {
            InitializeComponent();
        }
        public static  Form1 Instance
        {
            get
            {
                if (_form1 == null)
                {
                    _form1 = new Form1();  
                }
                return _form1;  
            }
        }
      
    }

    public partial class MyForm : Form
    {        
        UserControl1 uc; //this is the "instance".
        public MyForm ()
        {
            InitializeComponent();
            uc = new UserControl1();
            uc.SetIndicator(true); //start the busy indicator
            this.elementHost1.Child = uc;
        }
    }

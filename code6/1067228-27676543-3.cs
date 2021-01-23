    public partial class MyForm : Form
    {
        public MyForm ()
        {
            InitializeComponent();
            this.elementHost1.Child = new Stackoverflow.MyBusyIndicator();
        }
    }

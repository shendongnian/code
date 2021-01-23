     public partial class TabForm : Form
     {       
        public TabForm()
        {
            InitializeComponent();
            MyCustomTabControl customTab = new MyCustomTabControl(this.tabControl1);
        }
     }
:)

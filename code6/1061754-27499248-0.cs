    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                //Select tabpage after initialize
                tabControl1.SelectedTab = tabPage3;
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                //You can select it at form load or at some other action also like a button click
                //tabControl1.SelectedTab = tabPage3;
            }
        }
    }

    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            int myInt = 1; //This variable is accessible from every function in Form1
            List<string> myList;
            public Form1()
            {
                InitializeComponent();
                myList = new List<string>(); //Lists must be initialized in the constructor but defined outside the constructor as seen here
            }
            private void Form1_Load(object sender, EventArgs e)
            {
            }
        }
    }

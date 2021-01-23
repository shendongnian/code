    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            //This int and List will be accessible from every function within the Form1 class
            int myInt = 1;
            List<string> myList;
            public Form1()
            {
                InitializeComponent();
                myList = new List<string>(); //Lists must be initialized in the constructor as seen here - but defined outside the constructor as seen above
            }
            private void Form1_Load(object sender, EventArgs e)
            {
            }
            private void button1_Click(object sender, EventArgs e)
            {
                myInt = 1; //This function can access the int
                myList.Add("new item"); //This function can access the list
            }
            private void button2_Click(object sender, EventArgs e)
            {
                myInt = 0; //This function can also access the int
                myList.Clear(); //This function can also access the list
            }
        }
    }

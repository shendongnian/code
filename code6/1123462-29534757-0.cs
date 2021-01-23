	public partial class Form1 : Form, IMyInterface
    {
        MyLibraryClass mlc = null;
        public Form1()
        {
            InitializeComponent();
            mlc = new MyLibraryClass(this);
        }
        public void aMethod() {
            Console.Write("Test");
        }
    } 
	

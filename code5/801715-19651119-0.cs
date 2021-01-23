    public partial class MyForm : Form
    {
        private MyData dataIn;
        public MyData dataOut {get; set;}
        public MyForm(MyData data)
        {
            InitializeComponent();
            dataIn = data;
            dataOut = new MyData { v1 = "hi!", v2 = 2013 }; 
        }
    }

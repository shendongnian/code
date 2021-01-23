    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Base.ExceptionHandler.ShowErrorMessage += ExceptionHandler_ShowErrorMessage;
        }
        void ExceptionHandler_ShowErrorMessage(object sender, EventArgs e)
        {
            MessageBox.Show((string)sender);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Base.ExceptionHandler.test(new EventArgs());
        }
    }

    public partial class Form2 : Form
    {
        MainWindow mainWindow;
        public Form2()
        {
            InitializeComponent();
        }
    
        public Form2(MainWindow mainWndow)
            :this()
        {
            this.mainWindow = mainWndow;
        }
    
        public void DoWork()
        {
            if (this.mainWindow != null)
                this.mainWindow.button1.Text = "I set your text";
        }
    }

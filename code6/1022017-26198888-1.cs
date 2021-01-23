    public partial class MainWindow : ResizeWindow
    {
        public MainWindow()
        {
            this.Resized += MainWindow_Resized;
            this.Resizing += MainWindow_Resizing;
            InitializeComponent();
        }
        void MainWindow_Resizing(object sender, EventArgs e)
        {
            MessageBox.Show("Resizing!");
        }
        void MainWindow_Resized(object sender, EventArgs e)
        {
            MessageBox.Show("Resized!");
        }
    }

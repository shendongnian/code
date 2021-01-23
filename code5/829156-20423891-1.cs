    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            image1.MouseEnter += image1_MouseEnter;
            image2.MouseEnter += image1_MouseEnter;
            image3.MouseEnter += image1_MouseEnter;
            image4.MouseEnter += image1_MouseEnter;
            image1.MouseEnter += image1_MouseLeave;
            image2.MouseEnter += image1_MouseLeave;
            image3.MouseEnter += image1_MouseLeave;
            image4.MouseEnter += image1_MouseLeave;
            
        }
        private void image1_MouseEnter(object sender, MouseEventArgs e)
        {
        }
        private void image1_MouseLeave(object sender, MouseEventArgs e)
        {
        }
    }

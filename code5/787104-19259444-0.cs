    public partial class MainWindow : Window
    {
        private Student myOnlyStudent;
        public MainWindow()
        {
            InitializeComponent();
            myOnlyStudent = new Student()
        }
        private void btnSet_Click(object sender, RoutedEventArgs e)
        {
            myOnlyStudent.FirstName = txtFirstName.Text;
        }
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtFirstName.Clear();
        }
    }

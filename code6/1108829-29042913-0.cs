    public partial class MainWindow : Window
    {
        public class Dog
        {
            string name;
            int length;
            public Dog(string nm)
            {
                name = nm;
            }
        }
        private Dog maxwell;
        private Dog fred;
        public MainWindow()
        {
            InitializeComponent();
            maxwell = new Dog("Maxwell"); 
            fred = new Dog("Fred");
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LabelName.Content = maxwell.name;
        }  
    }

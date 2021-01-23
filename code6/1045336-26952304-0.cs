    namespace ComboBoxExampleWPF
    {
        class UserLevel
        {
            public UserLevel(int level, string description)
            {
                Level = level;
                Description = description;
            }
    
            public int Level { get; private set; }
            public string Description { get; private set; }
            
            // This controls how it shows up in the comboBox
            public override string ToString()
            {
                return Level.ToString() + " - " + Description;
            }
        }
    
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
                List<UserLevel> list = new List<UserLevel>()
                {
                    new UserLevel(1, "View Only"),
                    new UserLevel(2, "Basic User"),
                    new UserLevel(3, "Supervisor"),
                    new UserLevel(4, "Administrator"),
                    new UserLevel(5, "Super User")
                };
    
                comboBox1.ItemsSource = list;
                comboBox1.SelectionChanged += comboBox1_SelectionChanged;
            }
    
            void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                // ... Get the ComboBox.
                var comboBox = sender as ComboBox;
    
                // ... Set SelectedItem as Window Title.
                UserLevel value = comboBox.SelectedItem as UserLevel;
                this.Title = "Selected: " + value.ToString();
    
                SetUserLevel(value);
            }
    
            private void SetUserLevel(UserLevel ul)
            {
                // _myDatabase.SetUserLevel(ul.Level);
            }
        }
    }

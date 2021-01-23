    public MainWindow()
        {
            InitializeComponent();
            CreateControls();
        }
        private void CreateControls()
        {
            var c = new Customer("SomeFirstName", "SomeLastName", "Something");
            PropertyInfo[] pi = c.GetType().GetProperties();
            Label lbl;
            TextBox tb;
            StackPanel sp = new StackPanel();
            sp.Orientation = Orientation.Horizontal;
            foreach (var p in pi)
            {
                MessageBox.Show(p.Name);
                lbl = new Label();
                lbl.Content = p.Name;
                tb = new TextBox();
                tb.Text = p.GetValue(c, null).ToString();
                sp.Children.Add(lbl);
                sp.Children.Add(tb);
            }
           //Replace MainGrid with any control you want these to be added.
            MainGrid.Children.Add(sp);
        }
        
    }
    public class Customer
    {
        public Customer(string first, string last, string title)
        {
            FirstName = first;
            LastName = last;
            Title = title;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
    }

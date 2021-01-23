       public MainWindow()
        {
            InitializeComponent();
            List<string> lst = new List<string>();
            for (int i = 0; i < 10; i++)
            {
                //Button btn = new Button();
                //btn.Width = 50; btn.Height = 20;
                //btn.Content = i.ToString();
                lst.Add(i.ToString());
            }
            ic.ItemsSource = lst;
        }

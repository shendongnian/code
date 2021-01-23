        public MainPage()
        {
            InitializeComponent();
            tbx_a.TextChanged += (s, e) => { n = Convert.ToInt32(tbx_a.Text); };
        }
        TextBox[] Node;
        int[] a;
        int n = 8; // Number of boxes User wanna see in screen
        public void create_array()
        {
            a = new int[n];
            Node = new TextBox[n];
            for (int i = 0; i < n; i++)
            {
                //NODE
                a[i] = i;
                Node[i] = new TextBox();
                Node[i].Text = a[i].ToString();
                Node[i].Width = 80;
                Node[i].Height = 80;
                Node[i].Margin = new Thickness(2);
                Node[i].Foreground = new SolidColorBrush(Colors.White);
                Node[i].Background = new SolidColorBrush(Colors.Red);
                BoxStack.Children.Add(Node[i]);
            }
        }
        private void btn_Random_Click(object sender, RoutedEventArgs e)
        {
            Random r = new Random();
            for (int i = 0; i < n; i++)
            {
                a[i] = r.Next(100);
                Node[i].Text = a[i].ToString();
            }
        }
        private void btn_Array_Click(object sender, RoutedEventArgs e)
        {
            create_array();
        }

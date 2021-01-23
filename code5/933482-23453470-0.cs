     public MainWindow()
        {
            InitializeComponent();
            lbSource.Items.Add("example1@yahoo.com");
            lbSource.Items.Add("example2@gmail.com");
            lbSource.Items.Add("example3@hotmail.com");
            lbSource.Items.Add("example4@live.com");
           
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            txtShow.Text = "";
            foreach (string item in lbSource.Items)
            {
                string tmp = item.Substring(0, item.IndexOf('@'));
                txtShow.Text += tmp + "#";
            }
        }

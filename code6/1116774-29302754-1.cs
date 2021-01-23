        public MainWindow()
        {
            InitializeComponent();
        }
        private void btnclcik_Click(object sender, RoutedEventArgs e)
        {
            if (cb1.IsArrangeValid == true)
                if (cb2.IsArrangeValid == true)
                    txt1.Text = "Car:" + cb1.Text + "\n" + "state:" + cb2.Text;
            txt1.Text += " " + cb1.SelectedIndex.ToString();
        }
        private void btndel_Click(object sender, RoutedEventArgs e)
        {
            cb1.Text = "";
            cb2.Text = "";
        }

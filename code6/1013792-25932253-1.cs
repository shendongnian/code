        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Visibility rchOneVisible = rchOne.Visibility;
            switch (rchOneVisible)
            {
                case Visibility.Collapsed: rchOne.Visibility = Visibility.Visible;
                    break;
                default: rchOne.Visibility = Visibility.Collapsed;
                    break;
            }
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Visibility rchTwoVisible = rchTwo.Visibility;
            switch (rchTwoVisible)
            {
                case Visibility.Collapsed: rchTwo.Visibility = Visibility.Visible;
                    break;
                default: rchTwo.Visibility = Visibility.Collapsed;
                    break;
            }
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Visibility rchThreeVisible = rchThree.Visibility;
            switch (rchThreeVisible)
            {
                case Visibility.Collapsed: rchThree.Visibility = Visibility.Visible;
                    break;
                default: rchThree.Visibility = Visibility.Collapsed;
                    break;
            }
        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Visibility rchFourVisible = rchFour.Visibility;
            switch (rchFourVisible)
            {
                case Visibility.Collapsed: rchFour.Visibility = Visibility.Visible;
                    break;
                default: rchFour.Visibility = Visibility.Collapsed;
                    break;
            }
        }
    }

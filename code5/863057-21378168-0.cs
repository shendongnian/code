     public PeopleChooser()
            {
    
                this.Loaded += PeopleChooser_Loaded;
                InitializeComponent();                     
               
            }
      void PeopleChooser_Loaded(object sender, RoutedEventArgs e)
            {
                if (AllowMultiple)
                {
                    UsersListBox.Visibility = System.Windows.Visibility.Visible;
                    UserTextBox.Visibility = System.Windows.Visibility.Collapsed;
                    ResolveButton.Visibility = Visibility.Collapsed;            
    
                }
                else
                {
                    UsersListBox.Visibility = System.Windows.Visibility.Collapsed;
                    UserTextBox.Visibility = System.Windows.Visibility.Visible;
                    ResolveButton.Visibility = Visibility.Visible;
                }

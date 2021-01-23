       public YourUserControl()
            {
                InitializeComponent();
                dgv.SelectionChanged += dgv_SelectionChanged; 
                
            }
    
        void dgv_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                MySelectedItem = dgv.SelectedItem;
            }

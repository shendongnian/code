    <toolkit:ListPicker x:Name="Backgroundlist" Header="Background" SelectionChanged="Picker" ExpansionMode="FullscreenOnly" />
    public MainPage()
            {
                InitializeComponent();
                Backgroundlist.Items.Add("photo");
                Backgroundlist.Items.Add("Bing");
            }
    
            private void Picker(object sender, SelectionChangedEventArgs e)
            {
                var picker = sender as ListPicker;
                MessageBox.Show(picker.SelectedItem.ToString());
            }

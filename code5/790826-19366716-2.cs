     public ArrayList List { get; set; }
            public MainWindow()
            {
                InitializeComponent();
    
                
                SqlDataReader rdr = cmd.ExecuteReader();
                List = new ArrayList();
                while (rdr.Read()){
                    List.Add(new Class{ Id = rdr.GetString(0), Value = rdr.GetString(1), IsChecked= rdr.GetString(1) as bool}); //this class will contain the same data schema in your datareader but using properties 
                }
                rdr.Close();
                DataContext = List;
            }
      <ComboBox Name="ComboBox" ItemsSource="{Binding}" >
                <ComboBox.ItemTemplate>
                    <DataTemplate>
                        <StackPanel Orientation="Horizontal">
                            <CheckBox Tag="{Binding Id}" Content="{Binding Name}" IsChecked="{Binding IsChecked}"/>
                        </StackPanel>
                    </DataTemplate>
                </ComboBox.ItemTemplate>
            
            </ComboBox>

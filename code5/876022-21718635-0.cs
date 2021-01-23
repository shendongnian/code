    public class PersonViewModel : INotifyPropertyChanged
    {
        public string First { get; set; }
        public string Last { get; set; }
        // Implement INotifyPropertyChanged
    }
    public class MyComboSample : Window
    {
        public ObservableCollection<PersonViewModel> People {get; set;}
        public MyComboSample()
        {
            People = new ObservableCollection<PersonViewModel>();
            People.Add(new Person{First="Foo", Last="Bar"});
            DataContext = this;
            InitializeComponents();
        }
    }
    <!-- XAML Window -->
    <ComboBox ItemsSource="{Binding People}">
        <ComboBox.ItemTemplate>
            <DataTemplate>
                <StackPanel Orientation="Horizontal">
                    <TextBlock Text="{Binding First}"/>
                    <TextBlock Text="{Binding Last}"/>
                </StackPanel>
            </DataTemplate>
        </ComboBox.ItemTemplate>
    </ComboBox>

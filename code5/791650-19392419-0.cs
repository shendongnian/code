    //XAML
         <Grid>
               <DataGrid ItemsSource="{Binding Persons}" Margin="0,0,136,0" SelectedItem="{Binding SelectedPerson}"></DataGrid>
                <Label Content="{Binding SelectedPerson.Id}"  HorizontalAlignment="Left" Margin="400,35,0,0" VerticalAlignment="Top" Width="90" Height="26"/>
                <Label Content="{Binding SelectedPerson.Name}" HorizontalAlignment="Left" Margin="400,97,0,0" VerticalAlignment="Top" Width="90" Height="24"/>
                <Label Content="{Binding SelectedPerson.BirthDate}" HorizontalAlignment="Left" Margin="400,66,0,0" VerticalAlignment="Top" Width="90" Height="26"/>
            </Grid>
    //.cs
         public MainWindow()
            {
                InitializeComponent();
                DataContext = new PersonViewModel();
           }
    //ViewModel
        public class PersonViewModel : INotifyPropertyChanged
            {
                private Person _selectedPerson;
        
                public List<Person> Persons { get; set; }
        
                public Person SelectedPerson
                {
                    get { return _selectedPerson; }
                    set { _selectedPerson = value; OnPropertyChanged("SelectedPerson"); }
                }
        
                public PersonViewModel()
                {
                    Persons = new List<Person>
                    {
                        new Person(){Id = 1,BirthDate = DateTime.Now.AddYears(-30),Name = "Mark"},
                        new Person(){Id = 2,BirthDate = DateTime.Now.AddYears(-40), Name = "Sophy"},
                        new Person(){Id = 3,BirthDate = DateTime.Now.AddYears(-50), Name = "Bryan"},
                    };
                }
        
                
              
        
                public event PropertyChangedEventHandler PropertyChanged;
        
                [NotifyPropertyChangedInvocator]
                protected virtual void OnPropertyChanged(string propertyName)
                {
                    PropertyChangedEventHandler handler = PropertyChanged;
                    if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
                }
            }
    // Model     
    
        public class Person
            {
                public int Id { get; set; }
                public string Name { get; set; }
                public DateTime BirthDate { get; set; }
            }

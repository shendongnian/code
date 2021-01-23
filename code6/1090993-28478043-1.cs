    public class Person
    {
        public String FName { get; set; }   
        public String LName { get; set; }   
        
    }
    public partial class MainWindow : Window
    {
        public ObservableCollection<Person> ListPersons { get; set; }
        public MainWindow()
        {
            ListPersons=new ObservableCollection<Person>()
            {
                new Person()
                {
                    FName = "FName1",
                    LName = "LName1"
                },
                 new Person()
                {
                    FName = "FName2",
                    LName = "LName2"
                }
            };
            this.DataContext = this;
        }
       
    }
 

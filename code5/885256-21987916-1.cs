    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }
       protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            using (DatabaseContext c = new DatabaseContext(DatabaseContext.ConnectionString))
            {
                c.CreateIfNotExists(); 
                //Add new records for debug sake: 
                var dateNow = DateTime.UtcNow.TimeOfDay.ToString();
                var newToDo = new ToDoList { Col = "Col" + dateNow, Description = "Some description" + dateNow, Title = "Some title" + dateNow };
                c.ToDoLists.InsertOnSubmit(newToDo);
                c.SubmitChanges();
                lstToDos.ItemsSource = c.ToDoLists.ToList();
            }
        }
    }

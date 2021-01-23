    public partial class FormOneDataControl : UserControl
    {        
        public StudentViewModel ViewModel;
        public FormOneDataControl()
        {
            InitializeComponent();
            myCollectionViewSource.DataSource = StudentViewModel.GetStudents(); // or myCollectionViewSource.ItemsSource? Crap, can't pull the CollectionViewSource properties from raw memory...
        }  
     }

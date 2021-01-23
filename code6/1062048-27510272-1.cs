    public partial class FormOneDataControl : UserControl
    {        
        public StudentViewModel ViewModel;
        public FormOneDataControl()
        {
            InitializeComponent();
            myCollectionViewSource.DataSource = StudentViewModel.GetStudents();
        }  
     }

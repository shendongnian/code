      public partial class BindingTest : Window
      {
        public BindingTest()
        {
          InitializeComponent();
    
          Models.NamesModel nm = new Models.NamesModel();
          nm.Forename = "Bill";
          nm.Surname = "Gates";
          ViewModels.NamesViewModel vm = new ViewModels.NamesViewModel(nm);
    
    
          this.DataContext = vm;
        }
      }

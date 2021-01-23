    class MyView
    {
          MyView(int id)
            :this(new MyViewModel(id))
          {
          }
          MyView(MyViewModel viewModel)
          {
            InitializeComponent();
            this.DataContext = viewModel;
          }
    }
        
    class MyViewModel
    {
         private int _id;
         public int ID
         {
            get { return _id; }
            set { _id= value; OnPropertyChanged("ID"); }
         }
         public MyViewModel(int id)
         {
            ID=id;
         }
    }

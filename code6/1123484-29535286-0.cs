    MyView
        {
          MyView(int id)
          {
            InitializeComponent();
            ((MyViewModel)DataContext).ID = id;
          }
        }

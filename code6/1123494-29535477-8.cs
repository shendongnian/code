    MyView
    {
      MyView(int id)
      {
        InitializeComponent();
        ((MyViewModel)This.DataContext).ID = id;
      }
    }

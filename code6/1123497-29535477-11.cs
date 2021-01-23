    MyView
    {
      MyView(int id)
      {
        InitializeComponent();
        ((MyViewModel)this.DataContext).ID = id;
      }
    }

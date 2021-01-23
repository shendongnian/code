    MyView
    {
      MyView(int id)
      {
        InitializeComponent();
        Messenger.Default.Send<int>(id,"To MyViewModel");
      }
    }

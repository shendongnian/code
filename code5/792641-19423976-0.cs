    private static MainViewModel viewModel; //not sure how your viewmodel class is named
    public static MainViewModel ViewModel   //and a property to access it from
    {
      get
      {
        if(viewModel == null)               //which creates the viewModel just before
           viewModel = new MainViewModel(); //it's first used
        return viewModel;
      }
    }

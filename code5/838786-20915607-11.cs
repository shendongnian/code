    public ListView()
    {
      new ListPresenter(this); // initializes presenter
    }
    public void Show(IUser user) 
    { 
      new DetailsView(user); // creates a new view
    }

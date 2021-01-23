    //Declare this variables up in the app.xaml.cs class
    public GamePage GamePage;
    //In OnLaunched:
    var app = App.Current as App;
    // Create a main GamePage
    if (app.GamePage == null) app.GamePage = new GamePage(string.Empty);
    // Place the GamePage in the current Window
    Window.Current.Content = app.GamePage;
    Window.Current.Activate();

    public partial class App : Application
    {
      private static MainViewModel viewModel = new MainViewModel();
      public static MainViewModel ViewModel { get { return viewModel; } }
      ...

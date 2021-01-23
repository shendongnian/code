    public interface IMainWindowThatDoesSomething
    {
      void DoSomething();
    }
    
    public class MainWindow : Window, IMainWindowThatDoesSomething
    {
      // Constructor, methods, event handlers, etc. go here.
    
      public void DoSomething()
      {
        // Implementation here.
      } 
    }
    
    public class Page : Page
    {    
      private IMainWindowThatDoesSomething mainWindow;
    
      public Page(IMainWindowThatDoesSomething mainWindow)
      {
        InitializeComponent();
    
        this.mainWindow = mainWindow;
    
        // Other constructor jazz.
      }
    
      private void UserDidSomethingAndMainWindowNeedsToReact()
      {
        mainWindow.DoSomething();
      }
    }

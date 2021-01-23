    public partial class MainWindow : Window {
      public MainWindow() {
        this.InitializeComponent();
        var _ = InitializeAsync();
      }
      private static async Task InitializeAsync()
      {
        // TODO: error handling
        var result = await MyMethodAsync();
        Console.WriteLine(result);
      }
    }

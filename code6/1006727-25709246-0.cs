    public partial class MainWindow : Window
    {
      public MainWindow()
      {
        ClassLibrary1.Class1.WriteToFile("file.txt", "hi there!");
      }
    }

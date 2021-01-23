    namespace TestWpfProject
    {
      public partial class MainWindow : Window
      {
        public class Fruit
        {
          public string Name { get; set; }
          public string Category { get; set; }
        }
    
        public MainWindow()
        {
          Fruits = new ObservableCollection<Fruit>();
          InitializeComponent();
        }
    
        public ObservableCollection<Fruit> Fruits
        {
          get; set; 
        }
      }
    
      public class Categories
      {
        public List<string> CategoryList { get; set; }
        public Categories()
        {
          CategoryList = new List<string>() { "fruit", "vegetable", "grain" };
        }
      }
    }

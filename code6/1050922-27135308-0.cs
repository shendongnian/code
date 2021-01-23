    public partial class MyWindow: Window
    {
        public MyWindow()
        {
           InitializeComponent();
           this.DataContext = new ClassA();
        }
    }
    public class ClassA
    {
        public string Name { get; set; }
        public ClassB ClassB { get; set; }
    }
    public class ClassB
    {
        public string Name { get; set; }
    }

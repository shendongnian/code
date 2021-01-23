XAML
    <local:ListViewCustomControl Header="yolo"
                                 ElementsSource="{Binding TestList}" />
Code-behind
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var testData = new TestData();
            testData.TestList = new List<Type>();
            for (var i = 0; i < 123; i++)
                testData.TestList.Add(new Type(i));
            this.DataContext = testData;
        }
    }
    public class TestData 
    {
        public List<Type> TestList
        {
            get; 
            set; 
        }
    }

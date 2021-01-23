    public interface ITest
    {
        void Test();
    }
    public class MyControl : Control, ITest
    {
        public void Test()
        {
            MessageBox.Show("MyControl Test");
        }
    }
    public partial class MainWindow : Window, ITest
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public void Test()
        {
            MessageBox.Show("MainWindow Test");
        }
    }
    

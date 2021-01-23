       public partial class MainWindow : Window
        {
          public class MyClass
          {
           public int a { get; set; }
           public int b { get; set; }
           public int c { get; set; }
           public int d { get; set; }
          }
          public MainWindow()
          {
            InitializeComponent();
            MyClass obj;
            List<MyClass> bind = new List<MyClass>();
            for (int i = 0; i < 10; i++)
            {
                obj = new MyClass();
                obj.a = i;
                obj.b = 2*i;
                obj.c = 3*i;
                obj.d = 4*i;
                bind.Add(obj);
            }
            dataGrid1.ItemsSource = bind;
        }
        private void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            textBox1.Text = ((MyClass)dataGrid1.SelectedItem).c.ToString();
            
        }
    }

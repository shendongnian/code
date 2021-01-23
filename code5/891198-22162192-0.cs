    public partial class MainWindow {
		public MainWindow() {
			InitializeComponent();
			Console.WriteLine("Text is empty:{0}", TextBox1.Text == string.Empty);
			Console.WriteLine("Text is null:{0}", TextBox1.Text == null);
            Console.WriteLine();
            Console.WriteLine("TextBox.Text = null")
		    TextBox1.Text = null;
			Console.WriteLine("Text is empty:{0}", TextBox1.Text == string.Empty);
			Console.WriteLine("Text is null:{0}", TextBox1.Text == null);
		}
	}

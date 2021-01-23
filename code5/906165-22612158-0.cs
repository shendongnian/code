    public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			this.KeyDown += Form1_KeyDown;
		}
		void Form1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Up) { MessageBox.Show("|"); }
		}
	}

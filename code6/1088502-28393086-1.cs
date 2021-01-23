	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			
			var listBoxAdder = new ListBoxAdder(this.Running);
			listBoxAdder.Run();
		}
	}

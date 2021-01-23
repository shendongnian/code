	public partial class BaseForm: Form
	{
		//declared by default in .designer.cs
		//private System.Windows.Forms.TextBox textBox1;
		//change to:
		protected System.Windows.Forms.TextBox textBox1;
		private void InitializeComponent()
		{
			this.textBox1 = new System.Windows.Forms.TextBox();
		}
	}

	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}
		private void btnEditOnForm1_Click(object sender, EventArgs e)
		{
			var form2 = new Form2(richTextBoxOnForm1);
			form2.richTextBoxOnForm2.Text = richTextBoxOnForm1.Text;
			form2.ShowDialog(this);
		}
	}

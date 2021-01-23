	public partial class Form2 : Form
	{
		private readonly RichTextBox _rtb;
		public Form2(RichTextBox pRTB)
		{
			InitializeComponent();
			_rtb = pRTB;
		}
		private void btnOkOnForm2_Click(object sender, EventArgs e)
		{
			_rtb.Text = richTextBoxOnForm2.Text;
			this.Close();
		}
		private void btnCancelOnForm2_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}

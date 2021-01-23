	public partial class MyForm
	{
		private string _someValue = null;
		
		public void TextBox2_TextChanged(object sender, EventArgs e)
		{
			_someValue = "Some New Value";
		}
		
		public void Button1_Click(object sender, EventArgs e)
		{
			if (_someValue != null)
			{
				// ...
			}
		}	
	}

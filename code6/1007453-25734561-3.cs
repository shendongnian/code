		private void textBox11_TextChanged(object sender, EventArgs e)
		{
			string originalText = textBox11.Text;
			string[] splitString = originalText.Split(new Char[] { ' ' });
			String charset = "'NGXYIJAHKFTMC";
			
			foreach(String str in splitString)
			{
				((TextBox)this.Controls.Find("textBox" + charset.IndexOf(str[0]), true)).Text = str.Substring(1);;
			}       
		}

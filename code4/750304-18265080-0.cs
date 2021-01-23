    private void ColoritRed(RichTextBox rtb, string StringToHighlight)
		{
			int pos = 0;
			string searchText = StringToHighlight;
			pos = rtb.Find(searchText);
			while (pos != -1)
			{
				if (rtb.SelectedText == searchText)
				{
					this.ActiveControl = rtb;
					rtb.SelectionStart = pos;
					rtb.SelectionLength = searchText.Length;
					rtb.SelectionColor = Color.Red;
				}
				pos = rtb.Find(searchText, pos + 1, RichTextBoxFinds.MatchCase);
			}

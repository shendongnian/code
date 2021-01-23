	private void add_smileys(RichTextBox addin)
	{
		var smileys = new Dictionary<string, Image>()
		{
			{ @":)", Resources.in_smile },
			{ @">:(", Resources.in_angry },
			{ @":D", Resources.in_lol },
			{ @":'(", Resources.in_cry },
			{ @":(", Resources.in_sad },
			{ @";)", Resources.in_wink },
			{ @"xD", Resources.in_laugh },
			{ @":P", Resources.in_tongue },
			{ @":|", Resources.in_neutral },
			{ @"^^", Resources.in_happy },
			{ @"o.O", Resources.in_dizzy },
			{ @":S", Resources.in_confused },
			{ @":O", Resources.in_omg },
		};
		foreach (var smiley in smileys)
		{
			add_smiley(addin, smiley.Key, smiley.Value);
		}
	}
	private void add_smiley(RichTextBox addin, string token, Image smiley)
	{
		while (true)
		{
			var selectionStart = addin.Find(token, RichTextBoxFinds.WholeWord);
			if (selectionStart < 0) break;
			try
			{
				addin.SelectionStart = selectionStart;
				addin.SelectionLength = token.Length;
				Clipboard.SetImage(smiley);
				addin.Paste();
			}
			catch (Exception ex)
			{
				MessageBox.Show(e.Message);
				break;
			}
		}
	}

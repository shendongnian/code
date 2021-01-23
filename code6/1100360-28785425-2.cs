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
			add_smiley(addin, smiley);
		}
	}
	private void add_smiley(RichTextBox addin, KeyValuePair<string, Image> smiley)
	{
		while (true)
		{
			var selectionStart = addin.Find(smiley.Key, RichTextBoxFinds.WholeWord);
			if (selectionStart > -1)
			{
				try
				{
					addin.SelectionStart = selectionStart;
					addin.SelectionLength = smiley.Key.Length;
					Image img = smiley.Value;
					Clipboard.SetImage(img);
					addin.Paste();
				}
				catch (Exception ex)
				{
					MessageBox.Show(e.Message);
                    break;
				}
			}
			else
			{
				break;
			}
		}
	}

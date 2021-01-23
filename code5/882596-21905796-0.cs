	case XmlNodeType.Text: //De tekst in elk element weergeven.
	{
		tb1.Dispatcher.BeginInvoke(() =>
		{
			tb1.Text = tb1.Text + reader.Value + "\r\n";
		});
		Console.WriteLine(reader.Value);
	}
	break;

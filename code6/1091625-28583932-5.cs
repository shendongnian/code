	//Where rtfWriter.WriteToClipBoard is a modified version of the "Write" function:
	public void WriteToClipBoard(RtfDocument document)
	{
		_encoding = Encoding.GetEncoding((int)document.CodePage);
		sb = new StringBuilder();
		Reflect(document);
		Clipboard.SetData(DataFormats.Rtf, sb.ToString());
	}

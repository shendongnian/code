	using Microsoft.VisualBasic.FileIO;
	...
	private void ReadFunction()
	{
		using (TextFieldParser MyReader =
			new TextFieldParser(@"C:\temp\myData.csv"))
		{
			int lineRead = 1;
			while (!MyReader.EndOfData)
			{
				try
				{
					string[] fields = ParseHelper(MyReader.ReadLine(), lineRead++);
					Console.WriteLine(fields.Length.ToString());
				}
				catch (MalformedLineException ex)
				{
					Console.WriteLine(ex.Message);			
				}
			}
			Console.ReadKey();
		}
	}
	
	private string[] ParseHelper(String line, int lineRead)
	{
		MemoryStream mem = new MemoryStream(ASCIIEncoding.Default.GetBytes(line));
		TextFieldParser ReaderTemp = new TextFieldParser(mem);
		ReaderTemp.TextFieldType = FieldType.Delimited;
		ReaderTemp.SetDelimiters(new string[] { "\t", "," });
		ReaderTemp.HasFieldsEnclosedInQuotes = true;
		ReaderTemp.TextFieldType = FieldType.Delimited;
		ReaderTemp.TrimWhiteSpace = true;
		try
		{
			return ReaderTemp.ReadFields();
		}
		catch (MalformedLineException ex)
		{
			throw new MalformedLineException(String.Format(
				"Line {0} is not valid and will be skipped: {1}\r\n\r\n{2}",
				lineRead,ReaderTemp.ErrorLine, ex));
		}
	}

    using System.Text.RegularExpressions;
    
	private Regex regex = new Regex("[QWXYZ]");
	
	private void OnAddMessage(string message)
	{
		using (StringReader sr = new StringReader(message))
		{
			string line;
			
			while ((line = sr.ReadLine()) != null)
			{
				string[] splitContents = regex.Split(line);
				
				//do something with the parsed contents ...
			}
		}
	}

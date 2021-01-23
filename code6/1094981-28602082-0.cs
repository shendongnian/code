	using System.IO;
	
	class MyClass
	{
		protected bool FindWordInFile(StreamReader textfileReader, string wordToFind)
		{
			// Read the first line.
			string line = textfileReader.ReadLine();
			
			// The current line must not be null,
			// or we've reached the end of the file.
			while (line != null)
			{
				// TODO: Go find your word in the current line.
				
				// Read the next line.
				line = textfileReader.ReadLine();
			}
			
			// We didn't find the word in the file.
			return false;
		}
	}
	

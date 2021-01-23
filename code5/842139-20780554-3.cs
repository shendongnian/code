    		string longString = "Your long string goes here...";
			int chunkSize = 60;
			int chunks = longString.Length / chunkSize;
			int remaining = longString.Length % chunkSize;
			StringBuilder longStringBuilder = new StringBuilder();
			int index;
			for (index = 0; index < chunks * chunkSize; index += chunkSize)
			{
				longStringBuilder.Append(longString.Substring(index, chunkSize));
				longStringBuilder.Append(Environment.NewLine);
			}
			if (remaining != 0)
			{
				longStringBuilder.Append(longString.Substring(index, remaining));
			}
			string result = longStringBuilder.ToString().TrimEnd(Environment.NewLine.ToCharArray());

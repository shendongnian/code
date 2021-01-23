	private void CountWords(string cleanString)
	{
		foreach (string stringWord in cleanString.Split(' '))
		{
			if (head == null)
			{
				head = new WordNode(stringWord);
			}
			else
			{
				var last = (WordNode)null;
				var current = head;
				do
				{
					if (current.Word == stringWord)
					{
						break;
					}
					last = current;
					current = current.NextWord;
				} while (current != null);
				if (current != null)
				{
					current.Count++;
				}
				else
				{
					last.NextWord = new WordNode(stringWord);
				}
			}
		}
	}

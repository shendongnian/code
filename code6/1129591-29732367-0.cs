	public string getResidue(string main_word, string check_word)
	{
		foreach (char c in check_word)
		{
			int idx = main_word.IndexOf(c);
			if (idx > -1)
			{
				main_word = main_word.Remove(idx, 1);
			}
		}
		return main_word;
	}

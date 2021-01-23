	public class Hangman
	{
		string HangmanWord = "cookies";
		string WordUserCanSee = "-------";
		public Hangman()
		{
			IsThereA("o");
			IsThereA("f");
			IsThereA("k");
			IsThereA("w");
			IsThereA("i");
			IsThereA("c");
			IsThereA("s");
			IsThereA("e");
		}
		public bool IsThereA(string guessLetter)
		{
			bool anyMatch = false;
			for (int i = 0; i < HangmanWord.Length; i++)
			{
				if (HangmanWord.Substring(i, 1).Equals(guessLetter))
				{
					anyMatch = true;
					WordUserCanSee = WordUserCanSee.Substring(0, i) + guessLetter + WordUserCanSee.Substring(i + 1);
				}
			}
			return anyMatch;
		}
	}

	int max ;
	int index ;
	max = wordslist.Count() ;
	
	for (index = 0 ; index < max; index++)
	{
		if (wordslist[index] == text.Text)
		{
			if(index - 1 > 0)
			{
				Console.WriteLine("\n" + wordslist[index - 1]+ text.Text);
			}
			
			if(index + 1 < max)
			{
				Console.WriteLine("\n" + text.Text + " " + wordslist[index+1]);
			}
		}
	}

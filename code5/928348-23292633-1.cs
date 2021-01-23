    @{
        string[] words = item.Descritpion.Split(' ');
        int wordsPerLine = 25;
        for (int i = 0; i < words.Length; )
        {
            <p>
                @for (int j = 0; j < wordsPerLine && i < words.Length; i++, j++)
                {
                    @words[i]
                }
            </p>
        }
    }

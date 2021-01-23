    static void Main(string[] args)
    {
         filterStopWords("The lion the witch and the wardrobe");
    }
    private static void filterStopWords(string textToFilter)
    {
         var stopWords = new [] {"The", "or", "it"};
         textToFilter = textToFilter.ToLower();
         StringBuilder builder = new StringBuilder(textToFilter);
         for (int i = 0; i < 3; i++)
         {
                if (textToFilter.Contains(stopWords[i]))
                {
                    builder = builder.Replace(stopWords[i], " ");
                }
         }
         var result = builder.ToString();
         Console.WriteLine(result);
    }

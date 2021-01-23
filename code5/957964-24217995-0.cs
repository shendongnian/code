    (1)    for (int i = newText.Count - 1; i >= 0; i--)
           {
    (2)        for (int x = 0; x < WordsList.words.Length; x++)
               {
                   if (...)
                   {
    (3)                 newText.RemoveAt(i);
                   }
               }
           }

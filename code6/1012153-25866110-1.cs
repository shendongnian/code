    foreach (string sentence in sentenceList)
    {
       foreach (string word in keywords)
       {
          if (sentence.Contains(word))
          {
             if(!NewList.Contains(sentence))
                NewList.Add(sentence);
          }
       }
    }

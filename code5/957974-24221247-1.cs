    // For each 3-word-sets
    for (int x = 0; x < newText.Count; x += 3)
    {
       // For each word in that 3-word-set
       for (int k = x; k < 3; k++)
       {
          // Check each word
          bool breakOut = false;
          for (int y = 0; y < WordsList.words.Length; y++)
          {
             if (!newText[k].Contains(WordsList.words[y]))
             {
                newText.RemoveAt(x+2);
                newText.RemoveAt(x+1);
                newText.RemoveAt(x);
                x -= 3;
                breakOut = true;
                break;
             }
          }
          if (breakOut) { break; }
       }
    }

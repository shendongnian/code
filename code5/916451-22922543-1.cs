    string lastWord = null;
    int consec = 1;
    foreach(string word in namesList)
    {
       Console.WriteLine(word);
       if ( lastWord != null )
       {
          if( lastWord == word ){
             consec++;
             if ( consec == 4 )
             {
                break;  // 5 consecutive..
             }
          }
          else{
            consec = 0;
          }
       }
       lastWord = word;
     }

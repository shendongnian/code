     string GetRandomWord()
      {
        string[] linse=  System .IO.File .ReadAllLines (......) ;
          string mlines = "";
            foreach (string line in linse)
              {
                 if (line.Trim() != "")
                    if(mlines=="")
                        mlines = line;
                    else 
                    mlines = mlines +"\n"+ line;
              }
            string[] words = mlines. Split('\n');
     Random ran = new Random();
        return words[ran.Next(0, words.Length - 1)];
    }

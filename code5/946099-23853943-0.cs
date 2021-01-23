    string str = "8400*(413+x)+700";
    List<string> lstArray = new List<string>();
     for(int i=0; i<str.Length; i++)
     {
          if (Char.IsNumber(str[i]))
          {
               string sNum = str[i].ToString();
               if ((i + 1) < str.Length)
               {
                     for (int k = i+1; k < str.Length; k++)
                     {
                         if (Char.IsNumber(str[k]) == true)
                         {
                             sNum += str[k].ToString();
                             i = i + 1;
                         }
                         else
                            break;
                      }
               }
               lstArray.Add(sNum);
           }
           else if (Char.IsSymbol(str[i]))
           {
                lstArray.Add(str[i].ToString());                                  
           }
           else if (Char.IsLetter(str[i]))
           {
               string sLetter = str[i].ToString();
               
               if ((i + 1) < str.Length)
               {
                  for (int k = i + 1; k < str.Length; k++)
                  {
                      if (Char.IsLetter(str[k]) == true)
                      {
                          sLetter += str[k].ToString();
                          i = i + 1;
                      }
                      else
                          break;
                  }
              }
              lstArray.Add(sLetter);
          }
          else if (Char.IsPunctuation(str[i]))
          {                   
              lstArray.Add(str[i].ToString());
          }
      }

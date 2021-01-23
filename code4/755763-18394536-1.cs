    string[] word = new string[5];
    for (int i = 0;i<= word.length ; i++)
                {
                    
                   Console.WriteLine("Type in a word");
                    word[i] = Console.ReadLine();
                }
                int min = word[0].Length;
                int max = word[0].Length;
                string maxx="";
                string minn="";
    for (int i = 0; i<=word.length ; i++)
                {
                  int length = word[i].Length;   
                  if (length > max)
                     {
                       maxx = word[i];
                     
                      }
                 if (length < min) 
                  {
                     minn = word[i];
                    Console.Write("Longest");
                  }
    
    
    
             }
      Console.Write("Shortest:"+maxx);
      Console.Write("Longest"+minn);
      Console.ReadKey(true);
        }

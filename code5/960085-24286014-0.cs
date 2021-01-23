    class Program
        {    
            static void Main(string[] args)
            {
                List<string> words=new List<string>();                
                string word="";
                string str = "F12C429C420T16000000000000000000000000000000000000
                                         0000000000000000000000000000000000000000";
                foreach (char ch in str)
                {
                    if (char.IsLetter(ch))
                    {
                        words.Add(word);
                        word = ch.ToString();
                    }
                    else
                    {
                        word += ch.ToString();
                    }
                }
                words.Add(word);
                words.RemoveAt(0);
            }
          }

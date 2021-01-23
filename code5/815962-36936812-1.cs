    class Program
        {
           public static void Main(string[] args)
            {
                Console.WriteLine(FirstNonRepeated("tether"));
               Console.ReadKey();
            }
    
            public static char? FirstNonRepeated(string word)
            {
               char[] chararray= word.ToCharArray();
                Hashtable hashtable=new Hashtable();
                foreach (var c in chararray)
                {
                    if (hashtable.ContainsKey(c))
                    {
                        hashtable[c]=(int)hashtable[c]+1;
                    }
                    else
                    {
                        hashtable.Add(c,1);
                    }
                }
                foreach (var v in chararray)
                {
                    if ((int) hashtable[v] == 1)
                    {
                        return v;
                    }
                }
                return null;
            }
                
    
        }

     static bool[] charsHash = new bool[256];
            static bool IsUniqueChar(string str)
            {
                if (str.Length > 256) return false;
    
                foreach (char c in str)
                {
                    bool alreadyExist = charsHash[(int)c];
                    if (alreadyExist) return false;
                    else charsHash[(int)c] = !alreadyExist;
                   
                }
                return true;            
            }
     static void Main(string[] args)
        {
       
            Stopwatch sw = new Stopwatch();
            sw.Start();
            IsUniqueChar("Hello");
            sw.Stop();
           Console.WriteLine("Elapsed={0}", sw.Elapsed);//~000283
           Console.Read();
        }

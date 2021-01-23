    static Dictionary <string, int> HashCodes = new Dictionary<string, int>();
    static Random Rand = new Random();
    
    static int PsudoGetHashCode(string stringInQuestion)
    {
        lock(HashCodes)
        {
            int result;
            if(!HashCodes.TryGetValue(stringInQuestion, out result)
            {
                result = Rand.Next();
                HashCodes[stringInQuestion] = result;
            }
    
            return result;
        }
    }

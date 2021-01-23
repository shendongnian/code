    public static Dictionary<string, int> AddLevels(int AddLevel, int Question1, int Question2, int Answer)
    {
        Random rnd = new Random();
        Dictionary<string, int> dic = new Dictionary<string,int>();
    
        if(AddLevel == 0 || AddLevel == 1)
        {
           Question1 = rnd.Next(0, 10);
           Question2 = rnd.Next(0, 10);
           Answer = Question1 + Question2;
        }
    
        dic.Add("Question1", Question1);
        dic.Add("Question2", Question2);
        dic.Add("Answer", Answer);
        return dic;
    
    }

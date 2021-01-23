    void Main()
    {
        string test = "P I E T S N O T . C O M";
        Console.WriteLine(CheckSpaceLetterSequence(test));
        test = "Hi my name is";
        Console.WriteLine(CheckSpaceLetterSequence(test));
    }
    
    
    bool CheckSpaceLetterSequence(string test)
    {
        int count = 0;
        bool isSpace = (test[0] == ' ');
        for(int x = 1; x < test.ToCharArray().Length; x++)
        {
            bool curSpace = (test[x] == ' ');
            if(curSpace == isSpace)
                return false;
            
            isSpace = !isSpace;
            count++;
            if(count == 3)
               break;
        }
        return true;
    }

     private static char GenerateRandomLetter()
     {
        const string chars = "ABCEFGHJKPQRSTXYZ";
        Random rnd = new Random(); // you can avoid this allocation, put it class member            
        return chars[rnd.Next(0, chars.Length - 1)];
     }
    
     private static int GenerateRandomNumber()
     {
       Random rnd = new Random(); // you can avoid this allocation, put it class member
       return rnd.Next(2, 9);
     }
    
    void YourClientFunction()
    {
        // use a StringBuilder if you have a lot of concatenations
        string key = 
           GenerateRandomLetter()
         + GenerateRandomNumber().ToString()
         + GenerateRandomLetter()
         + GenerateRandomNumber().ToString();
        Console.WriteLine(key);
    }

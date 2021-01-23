    public static string GenerateRandomString(Random random , int minLength, 
                                                      int maxLength)
    {
        var length = GenerateRandomNumber(random , minLength, maxLength);
    
        var builder = new StringBuilder(length);   
    
        for (var i = 0; i < length; i++)
             builder.Append((char) random.Next(255));
    
        return builder.ToString();
    }
    public void GenerateRandomStringTest()
    {
        Random rnd = New Random();
        for (var i = 0; i < 100; i++)
        {
            var string1 = Utilitaries.GenerateRandomString(rnd, 10, 100);
            var string2 = Utilitaries.GenerateRandomString(rnd, 10, 20);
            if (string1.Contains(string2))
                throw new InternalTestFailureException("");
        }
    }

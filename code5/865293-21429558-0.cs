    private static string GenerateLetters(int size, bool lowercase) //added a return type
    {
     
         char[] chars = new char[size];
         Random r = new Random();
         for (int i = 0; i < size; i++)
         {
             chars[i] += Convert.ToChar(r.Next(65, 90));
         }
        if (lowercase)
               return new String(chars).ToLower();
         else
              return new String(chars);
            
    }

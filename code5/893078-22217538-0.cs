     string input = "AXBYCZ"; //Sample String
        StringBuilder output = new StringBuilder();
         
        char[] characters = input.ToCharArray();
         
        for (int i = 0; i < characters.Length; i++)
        {
          if (i % 2 == 0)
          {
            if((i+1) < characters.Length )
            {
              output.Append(characters[i + 1]);
            }
                       output.Append(characters[i]);
          }
        }

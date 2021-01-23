    char[] s3 = "*This is a string *with more than *one blocks *of values.".ToCharArray();
    StringBuilder s4 = new StringBuilder();
    for (int i = 0; i < s3.Length - 1; i++)
    {
       if (s3[i] == '*')
         s4.Append(s3[i+1]);
    }
    Console.WriteLine(s4.ToString());

    for(int i = 0; i < list.Length; i++)
    {
         list[i] = random.Next();
         if(i+1 < list.Length)
         {
             list[i+1] = random.Next();
         }
    }

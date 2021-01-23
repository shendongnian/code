    string[] Ar = new string[10];
    for (int i = 0; i < 10; i++)
    {
         if(String.IsNullOrEmpty(Ar[i]))
         {
           Ar[i]="NULL";
         }
    }
    for (int i = 0; i < 10; i++)
    {
            Console.WriteLine(Ar[i]);
    }

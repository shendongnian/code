    string[][] a = new string[100][];
    int bound0 = a.GetUpperBound(0);
    for(int i = 0; i <= bound0; i++)
    a[i] = new string[100];
    
    for (int i = 0; i <= bound0; i++)
    {
            int bound1 = a[i].GetUpperBound(0);
            for (int x = bound1; x >= 0; x--)
            {
                a[i][x] = (i+1).ToString() +"--"+ (x+1).ToString();
                string s1 = a[i][x];
                Console.WriteLine(s1);
            }
     }
 

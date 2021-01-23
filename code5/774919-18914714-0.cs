    private void FunctionName(int a, int b, int c, List<int[]> list)
    {
        if (a<10)
        { 
           if (b<20)
           {
               if (c<10)
               {
                   list.Add(new[] { a, b, c });
                   c++;
                   FunctionName(a,b,c,list);
                }
                else
                {
                     c=0;
                     b++;
                     FunctionName(a,b,c,list);
                }
           }
           else
           {
              b=0;
              a++;
              FunctionName(a,b,c,list);
           }
        }
     }

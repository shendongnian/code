    switch(arg[0])
    {
         case "a":
            DoStuff('a');
            break;
         case "b":
            DoStuff('b');
            break;
         default:
            break;
    }
    private void DoStuff(char c)
    {
       foreach(var c in obja)
       {
           if(c.entry == c)
           {
               if (Independent_condition_1)
               {
                   // do logging
                   continue;
               }
               if (Independent_condition_2)
               {
                    // do logging
                    continue;
               }
                  // Do something if above two conditions are false
            }
            else
            {
                if (Independent_condition_3)
                {
                    // do logging
                    continue;
                }
                if (Independent_condition_4)
                {
                    // do logging
                    continue;
                }
                // do something if above 2 conditions are false.
            }
        }
    }

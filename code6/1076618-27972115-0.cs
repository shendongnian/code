      while (lower < upper)
                {
                    ++num;
                    Console.WriteLine(num.ToString());
                    lower = num; //Added.  Else the loop is infinite
                }

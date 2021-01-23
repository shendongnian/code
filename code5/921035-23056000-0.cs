    bool numberfound=false;
    for (int i = 0; i < x; i++)
                {
                    for (int j = 0; j < y; j++)
                    {
                        if (MyArray[i, j].Equals(mynumber))
                        {
                           i=x;
                            numberfound=true;
                            break;
                        }
                        else
                        {
                            numberfound=false;
    break;
                        }
                    }            
                }
           if(numberfound)
                Console.WriteLine("The Number searched is {0}", mynumber);
    else{
                Console.WriteLine("End of search ");
                Console.ReadLine();}

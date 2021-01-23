           case '2':
                    Console.WriteLine("List of Cakes");
                    Console.WriteLine("id -.- Name -.- qty -.- price");
                    for (i = 0; i < counter; i++)
                    {
                       if(CakeArray[i]!=null){ // A safe check for null
                           Console.WriteLine("{0}  {1} {2} {3}", CakeArray[i].id, CakeArray[i].cake_Name, CakeArray[i].qty, CakeArray[i].price);
                   
                        }
                     }
                     Console.WriteLine("------------------");
                     break;

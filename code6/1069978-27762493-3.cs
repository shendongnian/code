     //DECLARATION
            
            //INTEGERS
            int max = 5;
            int i;
            int qty_search;
            int counter = 0, found = 0;
            char opt;
    		
    		Cake[] CakeArray = new Cake[max]; 
            do
            {
                Console.Write("1 - add cake\n2 - display cake\n3 - search cake\n4 - increase qty\n5 - decrease qty\n6 - Update qty\nx - exit\nopt --> ");
                opt = Convert.ToChar(Console.ReadLine());
                //SWITCH CASES
                switch (opt)
                {
                    //ADD CAKE
                    case '1':
    					CakeArray[counter] = new Cake();
    					
                        Console.Write("name: ");
                        CakeArray[counter].cake_Name= Console.ReadLine();
                        Console.Write("id: ");
                        CakeArray[counter].id = Console.ReadLine();
                        Console.Write("qty: ");
                        CakeArray[counter].qty= Convert.ToInt32(Console.ReadLine());
                        Console.Write("price: ");
                        CakeArray[counter].price = Convert.ToInt32(Console.ReadLine());
                        counter++;
                        break;
                    //DISPLAY CAKE
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
                    default:
                        Console.WriteLine("Invalid Option");
                        break;
                }
                //SWITCH CASE END
            } while (opt != 'x' && opt != 'X');
            //OUTER MENU LOOP END
            //PROGRAM TERMINATE
        } 

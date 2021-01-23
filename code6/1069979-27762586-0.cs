    static void Main(string[] args)
        {
            
            //INTEGERS
            int max = 5;
            Cake[] cakes = new Cake[max];
            int[] qty = new int[max];
            int[] price = new int[max];
            int i;
            int qty_search;
            int counter = 0, found = 0;
            //STRINGS
            string search;
            string[] cakename = new string[max];
            string[] id = new string[max];
            //CHAR'S
            char opt;
            //LOOP
            //MENU
            do
            {
                Console.Write("1 - add cake\n2 - display cake\n3 - search cake\n4 - increase qty\n5 - decrease qty\n6 - Update qty\nx - exit\nopt --> ");
                opt = Convert.ToChar(Console.ReadLine());
                //SWITCH CASES
                switch (opt)
                {
                    //ADD CAKE
                    case '1':
                        Console.Write("name: ");
                        cakename[counter] = Console.ReadLine();
                        cakes[counter] = new Cake();
                        cakes[counter].cake_Name = cakename[counter];
                        Console.Write("id: ");
                        id[counter] = Console.ReadLine();
                        cakes[counter].id = id[counter];
                        Console.Write("qty: ");
                        qty[counter] = Convert.ToInt32(Console.ReadLine());
                        cakes[counter].qty = qty[counter];
                        Console.Write("price: ");
                        price[counter] = Convert.ToInt32(Console.ReadLine());
                        cakes[counter].price = price[counter];
                        counter++;
                        break;
                    //DISPLAY CAKE
                    case '2':
                        Console.WriteLine("List of Cakes");
                        Console.WriteLine("id -.- Name -.- qty -.- price");
                        for (i = 0; i < max; i++)
                        {
                            Console.WriteLine("{0}  {1} {2} {3}", cakes[i].id, cakes[i].cake_Name, cakes[i].qty, cakes[i].price);
                        }
                        Console.WriteLine("------------------");
                        break;
                    //SEARCH CAKE
                    case '3':
                        found = 0;
                        Console.Write("enter your search cake id: ");
                        search = Console.ReadLine();
                        for (i = 0; i < counter; i++)
                        {
                            if (string.Equals(id[i], search, StringComparison.OrdinalIgnoreCase))
                            {
                                found++;
                            }
                        }
                        Console.Write("found = ");
                        Console.WriteLine(found);
                        break;
                    case '4':
                        Console.WriteLine("List of Cakes");
                        for (i = 0; i < counter; i++)
                        {
                            Console.WriteLine("{0}  {1}  {2}  {3}", cakes[i].id, cakes[i].cake_Name, cakes[i].qty, cakes[i].price);
                        }
                        Console.WriteLine("------------------");
                        Console.Write("Selected Item ID: ");
                        qty_search = Convert.ToInt32(Console.ReadLine());
                        for (i = 0; i < counter; i++)
                        {
                            if (qty_search == qty[i])
                            {
                                qty[i]++;
                            }
                        }
                        Console.WriteLine("cake qty + 1");
                        break;
                    case '5':
                        Console.WriteLine("List of Cakes");
                        for (i = 0; i < counter; i++)
                        {
                            Console.WriteLine("{0}  {1}  {2}  {3}", cakes[i].id, cakes[i].cake_Name, cakes[i].qty, cakes[i].price);
                        }
                        Console.WriteLine("------------------");
                        Console.Write("Selected Item ID: ");
                        qty_search = Convert.ToInt32(Console.ReadLine());
                        for (i = 0; i < counter; i++)
                        {
                            if (qty_search == qty[i])
                            {
                                qty[i]--;
                            }
                        }
                        Console.WriteLine("cake qty + 1");
                        break;
                    case '6':
                        Console.WriteLine("-- update cake name --");
                        Console.WriteLine("Cake list");
                        for (i = 0; i < counter; i++)
                        {
                            Console.WriteLine("{0}  {1}  {2}  {3}", cakes[i].id, cakes[i].cake_Name, cakes[i].qty, cakes[i].price);
                        }
                        Console.WriteLine("------------------");
                        Console.Write("Select item ID: ");
                        search = Console.ReadLine();
                        for (i = 0; i < counter; i++)
                        {
                            if (search == id[i])
                            {
                                Console.Write("Enter Name: ");
                                cakename[i] = Console.ReadLine();
                                Console.WriteLine("cake updated");
                            }
                        }
                        break;
                    case 'X':
                    case 'x':
                        Console.WriteLine("exit");
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

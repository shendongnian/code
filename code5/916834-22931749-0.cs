    Console.WriteLine("\n\n\t\tWhat is your option?\n\n\t\t  ");
            index = int.Parse(Console.ReadLine());
            switch (index)
            {
                case 1:
                    Console.Clear();
                    System.Console.WriteLine("\n\n\tHOW MANY ID'S FOR STUDENTS\n\n\t\t");
                    ids = int.Parse(Console.ReadLine());
                    for (i=0; i < ids; i++)
                    {
                        Console.WriteLine("\n\n\tPRESS 'u' FOR U.G. students,\n\n\t'm' FOR ONLY MASTERS and\n\n\t 'p' FOR ONLY PHD STUDENTS\n\n\t\t");
                        c[i] = Convert.ToChar(Console.ReadLine()); 
                        if (c[i] == 'u')
                        {
                            Console.Clear();
                            u[i].inputu(); //ug input
                        }

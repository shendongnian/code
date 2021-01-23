                Console.Write("\nEnter your age :  ");
                age = Int32.Parse(Console.ReadLine());
                if (age < 0 || age >= 110)
                {
                   //show error msg
                }
                Console.Write("\nEnter your pin :  ");
                pin = Int32.Parse(Console.ReadLine());
               //if every data is corrent - run function
               showinfo();   
    ////////////
               showinfo()
               { 
                Console.WriteLine("==============");
                Console.WriteLine("Your Complete Address:");
                Console.WriteLine("============\n");
                Console.WriteLine("Name = {0}", name);
                Console.WriteLine("City = {0}", city);
                Console.WriteLine("Age = {0}", age);
                Console.WriteLine("Pin = {0}", pin);
                Console.WriteLine("===============");
                Console.ReadLine();}

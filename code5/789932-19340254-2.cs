       public static int InputAge()
       {
            int age;
            Console.Write("Please enter the customer's age: ");
            if(int.TryParse(Console.ReadLine(), out age))
                return age;
            else
                return -1;
       }

        static void DeleteCustomer<T>(List<T> customers)
        {
            Console.WriteLine("Enter ID of customer to delete: ");
            int deleteId;
            if (int.TryParse(Console.ReadLine(), out deleteId)) // if the input is an int
            {
                Console.Write("Are you sure you want to delete this customer?");
                if (Console.ReadLine().ToLower() == "y")
                {
                    customers.RemoveAt(deleteId);
                }
            }
            else
            {
                Console.WriteLine("This is not valid Id");
            }
        }

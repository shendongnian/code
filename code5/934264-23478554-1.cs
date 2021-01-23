    class Customer : IComparable<Customer>  // SORT ARRAY - PART 2
    {
         public static void TotalDue(Customer [] customers)
         {
            double Total = 0;
            for (int x = 0; x < customers.Length; ++x)
                Total += customers[x].BalanceDue;
            Console.WriteLine("Total Amount Due:  {0}", Total.ToString("C2"));
         }
    }
    static void Main(string[] args)
    {
        // ...........
        //............
         Customer.TotalDue(customers);
    }
   

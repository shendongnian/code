        class Customer
        {
            string Name
            {
                get;
                set;
            }
            string Email
            {
                get;
                set;
            }
        }
        Customer[] customers = new Customer[50];
        //after initializing the array elements, you could do
        //assuming a for loop with i as index
        Customer currentCustomer = customers[i];
        currentCustomer.Name = "This";

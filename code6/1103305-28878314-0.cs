            unsafe 
            {
                // Assign the address of number to a pointer:
                int* p = &number;
    
                // Commenting the following statement will remove the
                // initialization of number.
                *p = 0xffff;
    
                // Print the value of *p:
                System.Console.WriteLine("Value at the location pointed to by p: {0:X}", *p);
    
                // Print the address stored in p:
                System.Console.WriteLine("The address stored in p: {0}", p->ToString());
            }

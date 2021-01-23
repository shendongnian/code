    string name;
    string city;
    int age;
    int pin;
    // \n is used for line-break
    Console.Write("Enter your name :  ");
    name = Console.ReadLine();
    Console.Write("\nEnter Your City :  ");
    city = Console.ReadLine();
    age = -1;
    while (age < 0 || age >= 110)
    {
        Console.Write("\nEnter your age :  ");
        age = Int32.Parse(Console.ReadLine());
        if (age < 0 || age >= 110)
        {
            Console.WriteLine("The age must be between 0 and 110.");
        }
    }
    
    Console.Write("\nEnter your pin :  ");
    pin = Int32.Parse(Console.ReadLine());
    // Printing message to console
    //formatting output
    Console.WriteLine("==============");
    Console.WriteLine("Your Complete Address:");
    Console.WriteLine("============\n");
    Console.WriteLine("Name = {0}", name);
    Console.WriteLine("City = {0}", city);
    Console.WriteLine("Age = {0}", age);
    Console.WriteLine("Pin = {0}", pin);
    Console.WriteLine("===============");
    Console.ReadLine();

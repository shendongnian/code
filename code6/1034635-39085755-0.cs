    age:
    Console.Write("\nEnter your age :  ");
    age = Int32.Parse(Console.ReadLine());
    if (age < 0 || age >= 110)
    {
        goto age;
    }
    Console.Write("\nEnter your pin :  ");
    pin = Int32.Parse(Console.ReadLine());

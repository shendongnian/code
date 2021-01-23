    int input = 0, result = 0;
    int sum = 0;
    Console.WriteLine("Give the number of which you want the sum.");
    input = int.Parse(Console.ReadLine());
    while (input != 0) 
    {
        sum += input % 10;
        input /= 10;
        
        result += sum; 
    }
    Console.WriteLine(result);

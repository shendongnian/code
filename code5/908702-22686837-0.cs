    int decToBin;
    Console.WriteLine("Enter a number that will be converted to binary");
    decToBin = Int32.Parse(Console.ReadLine());
    string bin = Convert.ToString(decToBin, 2);
    Console.WriteLine(bin); 

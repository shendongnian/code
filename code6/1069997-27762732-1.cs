    float price;
    Console.WriteLine("Enter the movie price");
    string input = Console.ReadLine();
    int successStatus = float.TryParse(input, out price);
    bool success = successStatus != 0;

    string input = Console.ReadLine();
    Console.WriteLine("=> Reversing...");
    char[] arrInput = input.ToCharArray();
    Array.Reverse(arrInput);
    String final = new String(arrInput);

    do
    {
        Input = Console.ReadKey(true);
        if(Input.Key != ConsoleKey.Enter)
           sb.Append(Input.KeyChar); 
    } while (Input.Key != ConsoleKey.Enter);

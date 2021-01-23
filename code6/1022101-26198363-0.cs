    StringBuilder sb = new StringBuilder();
    ConsoleKeyInfo Input;
    Console.Write("Input Your Hidden String: ");
    do
    {
    	 Input = Console.ReadKey(true);
    	 sb.Append(Input.KeyChar);                            //<--- here
    } while (Input.Key != ConsoleKey.Enter);
    Console.ReadLine();

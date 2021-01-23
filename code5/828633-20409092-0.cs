    private static string Password()
    {
        bool enter = true;
        string pass = "";
        do
        {
            char letter = Console.ReadKey(true).KeyChar;
            if (letter == (char)13)
            { enter = false; }
            else if (letter == (char)8 && pass.Length >= 1)
            {
                pass = pass.Remove(pass.Length - 1);
                Console.CursorLeft--;
                Console.Write('\0');
                Console.CursorLeft--;
            }
            //Additionally, don't print backspaces if it's the first character.
            else if (letter != (char)8)
            {
                pass += letter;
                Console.Write("*");
            }
        } while (enter);
        Console.WriteLine();
        return pass;
    }

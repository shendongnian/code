    Console.Write("Please enter a given character: ");
    var characterCode = Convert.ToInt32(Console.ReadKey().KeyChar).ToString();
    Console.WriteLine("");
    // Convert integer 182 as a hex in a string variable
    string characterRColor = characterCode.PadLeft(3, '0');
    string characterGColor = (Convert.ToInt32(characterCode) - 1).ToString().PadLeft(3, '0');
    string characterBColor = (Convert.ToInt32(characterCode) + 1).ToString().PadLeft(3, '0');
    Console.WriteLine("R Color: " + characterRColor);
    Console.WriteLine("G Color: " + characterGColor);
    Console.WriteLine("B Color: " + characterBColor);
    Console.ReadLine();

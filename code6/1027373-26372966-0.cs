    public static void cifrar()
    {
        Console.WriteLine("Escribe el mensaje");
        string letra = Console.ReadLine();
        letras l = (letras)Enum.Parse(typeof(letras), letra);
        Console.WriteLine("Cifrado: " + ((l + 5) % 53)); //Use the modulus operator to prevent going beyond the end of the enum
        Console.ReadLine();
    }
    public static void descifrar()
    {
        Console.WriteLine("Escribe el cifrado");
        string letra = Console.ReadLine(); ;
        letras l = (letras)Enum.Parse(typeof(letras), letra);
        int di = ((int)l) - 5; //Move back 5 letters
        if(di < 0) di = 53 - di; //We moved to a negative number, circle back to the end
        Console.WriteLine("Descifrado: " + ((letras)di));
        Console.ReadLine();
    } 

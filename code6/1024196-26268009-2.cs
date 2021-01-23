    static void Main(string[] args)
    {
        Dog fido = new Dog();
        int barking = 0;
        while (barking < 5)
        {
             fido.bark("Fido");
             barking++;
        }
        Console.Write("Hit any key to close"); Console.ReadKey(true);
    }

        double vari1, vari2;
        Console.WriteLine("Enter value");
        vari1 = double.Parse(Console.ReadLine());
        if (vari1 < 10000)
        {
            vari2 = (vari1 * .15);
        }
        else if (vari1 < 150000)
        {
            vari2 = (vari1 * .20);
        }
        else
        {
            Console.WriteLine("Nope");
            Console.ReadLine();
        }
        Console.ReadLine();

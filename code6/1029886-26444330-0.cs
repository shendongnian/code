        int x;
        int y;
        Console.WriteLine("enter x:");
        x = int.Parse(Console.ReadLine());
        Console.WriteLine("enter y:");
        y = int.Parse(Console.ReadLine());
        int z = (x > y)? 8 : 2;
        Console.WriteLine("x:{0} y:{1} z:{2}",x ,y, z);
        if (z > x)
        {
            Console.WriteLine("yoyo");
        }
        else { Console.WriteLine("hihi"); }
        Console.ReadLine();

            Console.Write("Enter x: ");
            double x = double.Parse(Console.ReadLine());
            Console.Write("Enter y: ");
            double y = double.Parse(Console.ReadLine());
            bool insideCircle = Math.Sqrt((x * x) + (y + y)) <= 2;

        static void Main(string[] args)
        {
            Random rand = new Random(Environment.TickCount);
            ConcurrentBag<Point3DCollection> bag = new ConcurrentBag<Point3DCollection>();
            for (int i = 0; i < 100; i++)
            {
                Point3DCollection coll = new Point3DCollection();
                bag.Add(coll);
                for (int j = rand.Next(10); j < rand.Next(100); j++)
                {
                    Point3D point = new Point3D(rand.NextDouble(), rand.NextDouble(), rand.NextDouble());
                    coll.Add(point);
                }
            }
            using (FileStream stream = new FileStream("test.bin", FileMode.Create))
            {
                bag.StringSerialize(stream); // or Binary
            }
            ConcurrentBag<Point3DCollection> newbag = new ConcurrentBag<Point3DCollection>();
            using (FileStream stream = new FileStream("test.bin", FileMode.Open))
            {
                newbag.StringDeserialize(stream); // or Binary
                foreach (Point3DCollection coll in newbag)
                {
                    foreach (Point3D point in coll)
                    {
                        Console.WriteLine(point);
                    }
                    Console.WriteLine();
                }
            }
        }
    }

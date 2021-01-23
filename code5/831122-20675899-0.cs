    public static class Point3DExtensions
    {
        public static void StringSerialize(this ConcurrentBag<Point3DCollection> bag, Stream stream)
        {
            if (bag == null)
                throw new ArgumentNullException("bag");
    
            if (stream == null)
                throw new ArgumentNullException("stream");
    
            StreamWriter writer = new StreamWriter(stream);
            Point3DCollectionConverter converter = new Point3DCollectionConverter();
            foreach (Point3DCollection coll in bag)
            {
                // we need to use the english locale as the converter needs that for parsing...
                string line = (string)converter.ConvertTo(null, CultureInfo.GetCultureInfo("en-US"), coll, typeof(string));
                writer.WriteLine(line);
            }
            writer.Flush();
        }
    
        public static void StringDeserialize(this ConcurrentBag<Point3DCollection> bag, Stream stream)
        {
            if (bag == null)
                throw new ArgumentNullException("bag");
    
            if (stream == null)
                throw new ArgumentNullException("stream");
    
            StreamReader reader = new StreamReader(stream);
            Point3DCollectionConverter converter = new Point3DCollectionConverter();
            do
            {
                string line = reader.ReadLine();
                if (line == null)
                    break;
    
                bag.Add((Point3DCollection)converter.ConvertFrom(line));
                
                // NOTE: could also use this:
                //bag.Add(Point3DCollection.Parse(line));
            }
            while (true);
        }
    
        public static void BinarySerialize(this ConcurrentBag<Point3DCollection> bag, Stream stream)
        {
            if (bag == null)
                throw new ArgumentNullException("bag");
    
            if (stream == null)
                throw new ArgumentNullException("stream");
    
            BinaryWriter writer = new BinaryWriter(stream);
            writer.Write(bag.Count);
            foreach (Point3DCollection coll in bag)
            {
                writer.Write(coll.Count);
                foreach (Point3D point in coll)
                {
                    writer.Write(point.X);
                    writer.Write(point.Y);
                    writer.Write(point.Z);
                }
            }
            writer.Flush();
        }
    
        public static void BinaryDeserialize(this ConcurrentBag<Point3DCollection> bag, Stream stream)
        {
            if (bag == null)
                throw new ArgumentNullException("bag");
    
            if (stream == null)
                throw new ArgumentNullException("stream");
    
            BinaryReader reader = new BinaryReader(stream);
            int count = reader.ReadInt32();
            for (int i = 0; i < count; i++)
            {
                int pointCount = reader.ReadInt32();
                Point3DCollection coll = new Point3DCollection(pointCount);
                for (int j = 0; j < pointCount; j++)
                {
                    coll.Add(new Point3D(reader.ReadDouble(), reader.ReadDouble(), reader.ReadDouble()));
                }
                bag.Add(coll);
            }
        }
    }

    static void Main(string[] args)
            {
                var pixelscoordinatesinrectangle = new List<Point>() { new Point(200, 100), new Point(100, 100), new Point(200, 200) };
                var newpixelscoordinates = new List<Point>() { new Point(200, 100), new Point(400, 400) };
    
                FindMatchingPoints(pixelscoordinatesinrectangle, newpixelscoordinates);
    
                Console.ReadKey();
            }
    
            private static void FindMatchingPoints(List<Point> pixelscoordinatesinrectangle, List<Point> newpixelscoordinates)
            {
                if (pixelscoordinatesinrectangle != null && newpixelscoordinates != null)
                {
                    IEnumerable<Point> matchingPoints = pixelscoordinatesinrectangle.Where(p => newpixelscoordinates.Contains(p));
    
                    // Execute the query.
                    foreach (Point s in matchingPoints)
                        Console.WriteLine("The following points are the same" + s);
                }
    
            }

            Point? P1 =  null;
            Point? P2 = null;
            Point? P3 = null;
            List<Point?> points = new List<Point?>();
            bool rainbows = true;
            bool butterflies = false;
            bool unicorns = true;
            if (rainbows)
            {
                P1 = new Point(100, 200);
                points.Add(P1);
            }
            if (butterflies)
            {
                P2 = new Point(444, 555);
                points.Add(P2);
            }
            if (unicorns)
            {
                P3 = new Point(123, 456);
                points.Add(P3);
            }
            // Usually will have three points here, but if not, quit    
            if (points.Count < 3) { }
            // We have three points here. 
            // For sure, P1, P2, P3 have all been assigned
            DoSomethingWithPoint(P1);   // ERROR unassigned var P1

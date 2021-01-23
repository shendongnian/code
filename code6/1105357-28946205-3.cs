        [TestMethod]
        public void IntersectingPoints_AreCorrect()
        {
            // The line y=x intersects a 1x1 image at points (0, 0) and (1, 1).
            var results = GetIntersectionsForImage(1.0, 0.0, 1.0, 1.0);
            foreach (var p in new List<Point> { new Point(0.0, 0.0), new Point(1.0, 1.0) })
            {
                Assert.IsTrue(results.Contains(p));
            }
            // The line y=1 intersects a 2x2 image at points (0, 1), and (2, 1).
            results = GetIntersectionsForImage(0.0, 1.0, 2.0, 2.0);
            foreach (var p in new List<Point> { new Point(0.0, 1.0), new Point(2.0, 1.0) })
            {
                Assert.IsTrue(results.Contains(p));
            }
        }

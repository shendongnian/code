    [TestMethod]
        public void IntersectingPoints_AreCorrect()
        {
            var results = GetIntersectionsForImage(1.0, 0.0, 1.0, 1.0);
            foreach (var p in new List<Point> {new Point(0.0, 0.0), new Point(1.0, 1.0)})
            {
                Assert.IsTrue(results.Contains(p));
            }
            results = GetIntersectionsForImage(0.0, 1.0, 2.0, 2.0);
            foreach (var p in new List<Point> { new Point(0.0, 1.0), new Point(2.0, 1.0) })
            {
                Assert.IsTrue(results.Contains(p));
            }
        }

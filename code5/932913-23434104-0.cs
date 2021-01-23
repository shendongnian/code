    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    namespace MyNamespace
    {
        [TestClass]
        public class OtherTests
        {
            readonly Random rand = new Random();
            [TestMethod]
            public void CoordTest()
            {
                double width = 400;
                double height = 400;
                double centerScreenX = width / 2;
                double centerScreenY = height / 2;
                double minSpeed = 5;
                double maxSpeed = 10;
                double offsetRangeX = 0;
                double offsetRangeY = 100; // Only up and down.
                List<double[]> vectors = new List<double[]>();
                int spritesToGenerate = 3;
                while (spritesToGenerate-- > 0)
                {
                    vectors.Add(new[]
                    {
                        centerScreenX + rand.NextDouble() * offsetRangeX * 2 - offsetRangeX,
                        centerScreenY + rand.NextDouble() * offsetRangeY * 2 - offsetRangeY,
                        rand.NextDouble() * (maxSpeed - minSpeed) + minSpeed,
                        rand.NextDouble() * (maxSpeed - minSpeed) + minSpeed
                    });
                }
                Console.WriteLine(string.Join("\r\n", vectors.Select(v => string.Join("\t", v))));
            }
        }
    }

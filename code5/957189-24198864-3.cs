        public void TestMethod1()
        {
            var doc = XDocument.Load(xmlFile);
            double area=0;
            foreach (var shapeItem in doc.Descendants("bag").Descendants())
            {
                var type = Type.GetType("StackOverflowShapes." + shapeItem.Name + ",StackOverflowShapes");
                var myShape = (shape)Activator.CreateInstance(type, shapeItem);
                area += myShape.Area();
                var element = myShape.GetXElement();
                Console.WriteLine(element);
            }
            Assert.Equal(129.5398, area, 4);
        }

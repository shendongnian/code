        [Fact]
        public void Test()
        {
            XElement root = XElement.Load("dPrzypo.xml");
            root.Add(
                new XElement(
                    "przypom",
                    new XElement("data", "10 February 2014"),
                    new XElement("opis", "hjkjk")));
            root.Save("dPrzypo.xml");
        }

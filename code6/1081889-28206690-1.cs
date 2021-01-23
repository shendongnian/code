        [Test]
        public void Map_Test()
        {
            var result = Map(new A_To_B()
                , File.ReadAllText("A.xml")
                , File.ReadAllText("A_To_B_extxml.xml"));
            Assert.IsNotNullOrEmpty(result);
        }

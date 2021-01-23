        [Test]
        public void Banana([Values (".ClassThree")] string targetClass, [Values ("#A32DF1")] string expectedColor)
        {
            var parser = new Parser();
            var sheet = parser.Parse(sample);
            var result = sheet.Rulesets
                .Where(s => s.Selector.ToString() == targetClass)
                .SelectMany(r => r.Declarations)
                .FirstOrDefault(d => d.Name.Equals("background-color", StringComparison.InvariantCultureIgnoreCase))
                .Term
                .ToString();
            Assert.AreEqual(expectedColor, result);            
        }

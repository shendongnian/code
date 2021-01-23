        public Setting(string name)
        {
            if (name == null) throw new ArgumentNullException("name");
            Name = name;
        }
        public string Name { get; private set; }
    }
    public class SettingsParser
    {
        public Setting ExtractLine(string line)
        {
            var pos = line.IndexOfAny(new[] {'='});
            var setting = new Setting(line.Substring(0, pos));
            return setting;
        }
    }
    [TestClass]
    public class ParserTests
    {
        [TestMethod]
        public void Should_be_able_to_extract_name_from_a_line()
        {
            var line = "G195=Out:LED0799,LED0814,Flags:L-N Desc:\"EAF-QCH-B1-01\" Invert:00 STO:35 SP:0 FStart: FStop: ";
            var sut = new SettingsParser();
            var actual = sut.ExtractLine(line);
            Assert.AreEqual("G195", actual.Name);
        }
    }

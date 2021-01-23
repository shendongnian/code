    using NUnit.Framework;
    [TestFixture]
    class NustacheUtilTests
    {
        [Test]
        public void PreProcessTest_Single()
        {
            // Arrange
            const string templateString = "Test number: {{MyNumber|3}}";
            // Act
            var result = NustacheUtil.PreProcess(templateString);
            // Assert
            Assert.That(result, Is.EqualTo("Test number: <###{{MyNumber}}|3###>"));
        }
        [Test]
        public void PostProcessTest_Single()
        {
            // Arrange
            const string templateString = "Test number: <###123.456789|3###>";
            // Act
            var result = NustacheUtil.PostProcess(templateString);
            // Assert
            Assert.That(result, Is.EqualTo("Test number: 123.457"));
        }
        [Test]
        public void PreProcessTest_Multiple()
        {
            // Arrange
            const string templateString = "Test number: {{MyNumber|3}}, and another: {{OtherNumber|2}}";
            // Act
            var result = NustacheUtil.PreProcess(templateString);
            // Assert
            Assert.That(result, Is.EqualTo("Test number: <###{{MyNumber}}|3###>, and another: <###{{OtherNumber}}|2###>"));
        }
        [Test]
        public void PostProcessTest_Multiple()
        {
            // Arrange
            const string templateString = "Test number: <###123.457|3###>, and another: <###947.74933|2###>";
            // Act
            var result = NustacheUtil.PostProcess(templateString);
            // Assert
            Assert.That(result, Is.EqualTo("Test number: 123.457, and another: 947.75"));
        }
    }

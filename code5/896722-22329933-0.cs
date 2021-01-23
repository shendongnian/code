        [Test]
        public void Find_index_in_string()
        {
            // Arrange
            const string str = "2952885619_Table!$1$4";
            // Act
            var matches = Regex.Matches(str, @"\$(\d+)\$(\d+)");
            // Assert
            Assert.That(matches.Count, Is.EqualTo(1));
            Assert.That(matches[0].Groups[0].ToString(), Is.EqualTo("$1$4"));
            Assert.That(matches[0].Groups[1].ToString(), Is.EqualTo("1")); // Extracted index 1
            Assert.That(matches[0].Groups[2].ToString(), Is.EqualTo("4")); // Extracted index 2
        }

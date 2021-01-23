        [TestCase("Hello world","world")]
        [TestCase("Hello world", "bye", ExpectedException = typeof(AssertionException))]
        public static void ShouldContain(this string str, string subStr)
        {
            Assert.That(str, Contains.Substring(subStr));
        }

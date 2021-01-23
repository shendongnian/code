    public static class Extensions
    {
        private static Random rand = new Random(1);
        public static char Random(this string str)
        {
            return str[rand.Next(str.Length)];
        }
    }
    [TestClass]
    public class StackOverflow
    {
        [TestMethod]
        public void MyTestMethod()
        {
            string s = "ŚśŜŝŞşŠšƧƨȘșȿʂϨϩЅѕᵴṠṡṢṣṤṥṦṧṨṩ$§";
            HashSet<char> expected = new HashSet<char>();
            HashSet<char> actual = new HashSet<char>();
            foreach (char c in s)
            {
                expected.Add(c);
            }
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 1000; i++)
            {
                sb.Append(s.Random());
            }
            string str = sb.ToString();
            foreach (char c in str)
            {
                actual.Add(c);
            }
            Assert.AreEqual(1000, str.Length);
            CollectionAssert.AreEquivalent(expected.ToList(), actual.ToList());
        }
    }

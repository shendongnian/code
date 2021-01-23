        [Test()]
        public void TestNegativePadding()
        {
            int number1 = 123;
            int number2 = -123;
            Assert.AreEqual(" 00000123", string.Format("{0,9:D8}", number1));
            Assert.AreEqual("-00000123", string.Format("{0,9:D8}", number2));
            string str = "";
            int[] test = {3232, 2132, -545, 646545, -465};
            foreach (var number in test)
            {
                str += string.Format("{0,9:D8}", number);
            }
            Assert.AreEqual("00003232 00002132-00000545 00646545-00000465", str.Trim());
        }

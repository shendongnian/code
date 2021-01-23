        [Test]
        public void SByte()
        {
            sbyte? nullableSbyte = sbyteValueFromByte;
            Assert.AreEqual(nullableSbyte.Value, 127); // True
            Assert.AreEqual(nullableSbyte, 127);
        }

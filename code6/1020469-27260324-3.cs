    [TestClass]
    public class ComparerTests
    {
        public enum ByteEnum : byte
        {
            One = 1, Two = 2
        }
        public enum IntEnum
        {
            One = 1, Two = 2, MegaLarge = 100500
        }
        [TestMethod]
        public void EqualsTest()
        {
            Assert.IsTrue(Comparer.Equals(2, 2));
            Assert.IsFalse(Comparer.Equals(1,2));
            Assert.IsTrue(Comparer.Equals(1, IntEnum.One));
            Assert.IsFalse(Comparer.Equals(1, IntEnum.Two));
            Assert.IsTrue(Comparer.Equals(ByteEnum.One, IntEnum.One));
            Assert.IsFalse(Comparer.Equals(ByteEnum.One, IntEnum.Two));
            Assert.IsFalse(Comparer.Equals(ByteEnum.One, IntEnum.MegaLarge)); 
        }
    }

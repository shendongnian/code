    public class ParameterizedTestFixture
    {
        public static IEnumerable<object[]> TestCases = new[] {
            new object[] { "hello", "hello", "goodbye" },
            new object[] { "zip", "zip", null },
            new object[] { 42, 42, 99 }
        };
        private string eq1;
        private string eq2;
        private string neq;
        public void Init(object _eq1, object _eq2, object _neq)
        {
            this.eq1 = (_eq1 == null ? null : _eq1.ToString());
            this.eq2 = (_eq2 == null ? null : _eq2.ToString());
            this.neq = (_neq == null ? null : _neq.ToString());
        }
        [Theory]
        [MemberData(nameof(TestCases))]
        public void TestEquality(object _eq1, object _eq2, object _neq)
        {
            Init(_eq1, _eq2, _neq);
            Assert.Equal(eq1, eq2);
            if(eq1 != null && eq2 != null)
                Assert.Equal(eq1.GetHashCode(), eq2.GetHashCode());
        }
        [Theory]
        [MemberData(nameof(TestCases))]
        public void TestInequality(object _eq1, object _eq2, object _neq)
        {
            Init(_eq1, _eq2, _neq);
            Assert.NotEqual(eq1, neq);
            if(eq1 != null && neq != null)
                Assert.NotEqual(eq1.GetHashCode(), neq.GetHashCode());
        }
    }

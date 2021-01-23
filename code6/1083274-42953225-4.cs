    public class ParameterizedTestFixture
    {
        public static IEnumerable<object[]> TestCases = new[] {
            new object[] { "hello", "hello", "goodbye" },
            new object[] { "zip", "zip", null },
            new object[] { "42", "42", "99" }
        };
        [Theory]
        [MemberData(nameof(TestCases))]
        public void TestEquality(string eq1, string eq2, string neq)
        {
            Assert.Equal(eq1, eq2);
            if(eq1 != null && eq2 != null)
                Assert.Equal(eq1.GetHashCode(), eq2.GetHashCode());
        }
        [Theory]
        [MemberData(nameof(TestCases))]
        public void TestInequality(string eq1, string eq2, string neq)
        {
            Assert.NotEqual(eq1, neq);
            if(eq1 != null && neq != null)
                Assert.NotEqual(eq1.GetHashCode(), neq.GetHashCode());
        }
    }

        private ICollection<UserTest> _userTests;
        public class ComplexTest : Test
        {
            public override ICollection<UserTest> UserTests
            {
              get { return _userTests.Where(...)} //class-specific logic 
              set { _userTests = value }
            }
        }

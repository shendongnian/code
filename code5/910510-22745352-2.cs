        private ICollection<UserTest> _userTests;
        public class ChildTest : Test
        {
            public override ICollection<UserTest> UserTests
            {
              get { return _userTests.Where(...)} //Do some manipulation on the collection 
              set{ _userTests = value }
            }
        }

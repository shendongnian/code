        private ICollection<UserTest> _userTests;
        public class ChildTest: Test
        {
            public override ICollection<UserTest> UserTests
            {
              get { return ..}
              set{ _userTests = value }
            }
        }

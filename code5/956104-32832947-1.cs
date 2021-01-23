    public class TestValidator : InlineValidator<TestObject>
    {
        public TestValidator (params Action<TestValidator >[] actions)
        {
            foreach (var action in actions)
            {
                action(this);
            }
        }
    }

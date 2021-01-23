        public static AndConstraint<GuidAssertions> BeGuid(this StringAssertions value, string because = "", params object[] becauseArgs)
        {
            Guid.TryParse(value.Subject, out var guid);
            return guid.Should().NotBeEmpty(because, becauseArgs);
        }
        public static AndConstraint<GuidAssertions> BeGuid(this ObjectAssertions value, string because = "", params object[] becauseArgs)
        {
            return (value.Subject as Guid?).Should().NotBeNull().And.NotBeEmpty(because, becauseArgs);
        }

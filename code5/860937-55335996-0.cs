        public static AndConstraint<FluentAssertions.Primitives.GuidAssertions> ShouldBeGuid(this object value, string because = "", params object[] becauseArgs)
        {
            Guid.TryParse(value?.ToString(), out var guid);
            return guid.Should().NotBeEmpty(because, becauseArgs);
        }

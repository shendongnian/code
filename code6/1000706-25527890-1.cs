	public class OneOfValuesConstraint : EqualConstraint
	{
		readonly ICollection expected;
		NUnitEqualityComparer comparer = new NUnitEqualityComparer();
		public OneOfValuesConstraint(ICollection expected)
			: base(expected)
		{
			this.expected = expected;
		}
		public override bool Matches(object actual)
		{
            // set the base class value so it appears in the error message
			this.actual = actual;
			Tolerance tolerance = Tolerance.Empty;
            // Loop through the expected values and return true on first match
			foreach (object value in expected)
				if (comparer.AreEqual(value, actual, ref tolerance))
					return true;
            // No matches, return false
			return false;
		}
        // Overridden for a cleaner error message (contributed by @chiccodoro)
        public override void WriteMessageTo(MessageWriter writer)
        {
            writer.DisplayDifferences(this);
        }
        public override void WriteDescriptionTo(MessageWriter writer)
        {
            writer.Write("either of ");
            writer.WriteExpectedValue(this.expected);
        }
	}

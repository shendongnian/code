	[TestMethod]
	public void SplitByDelimitersTest() {
		// Replace the spaces in this string, it makes it possible to get the data using the extension method.
		var data = "PT01 0200LB  Wax  N011 00000000500030011 00000000".Replace(" ", "");
		var result = data.Split(0, 2, 8);
		var expected = new[] { "PT", "010200", "LBWaxN0110000000050003001100000000" };
		CollectionAssert.AreEqual(expected, result, "Collections were not equal in the SplitByDelimeters test.");
	}

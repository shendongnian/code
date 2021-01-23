		[TestMethod]
		public void TestMethod()
		{
			// arrange
			var foo = new Foo();
			var target = new FooToBarsConverter();
			// act + assert
			var list = target.Convert(foo);
			list.Should().HaveCount(2);
			list.Should().NotContainNulls();
			var typeA = target.CreateBar<Bar.BarA>(foo);
			typeA.Should().BeAssignableTo<Bar.BarA>();
			var typeB = target.CreateBar<Bar.BarB>(foo);
			typeB.Should().BeAssignableTo<Bar.BarB>();
		}

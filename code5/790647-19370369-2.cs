		[Test]
		public void TestInvalidConstructorArg()
		{
            var ex = Assert.Throws<TargetInvocationException>(() => Substitute.For<MyClass>(-5));
            Assert.That(ex.InnerException, Is.TypeOf(typeof(ArgumentOutOfRangeException)));
		}

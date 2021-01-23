    [TestClass]
	public class UnitTest2
	{
		private Mock<IRepository> moqRepository;
		private PersonService service;
		[TestInitialize]
		public void TestInitialize()
		{
			moqRepository = new Mock<IRepository>();
			service = new PersonService(moqRepository.Object);
		}
		[TestMethod]
		public void TestMethod3()
		{
			// arrange
			var persons = new List<Person>
			{
				new Person { Age = 0 },
				new Person { Age = 1 },
				new Person { Age = 17 },
				new Person { Age = 18 },
				new Person { Age = 19 },
				new Person { Age = 100 }
			};
			moqRepository
				.Setup(x => x.GetForExpression(It.IsAny<Expression<Func<Person, bool>>>()))
				.Returns<Expression<Func<Person, bool>>>(expr => persons.Where(expr.Compile()).ToList());
			// act
			var result = service.GetAllPersonsWith18More();
			// assert
			moqRepository.VerifyAll();
			result.Should().BeEquivalentTo(persons.Where(x => x.Age > 18));
		}
		[TestMethod]
		public void TestMethod4()
		{
			// arrange
			Expression<Func<Person, bool>> criteria = x => x.Age > 18;
			moqRepository
				.Setup(x => x.GetForExpression(It.IsAny<Expression<Func<Person, bool>>>()))
				.Returns(new List<Person>())
				.Callback<Expression<Func<Person, bool>>>(expr =>
				{
					var persons = new List<Person>
					{
						new Person { Age = 0 },
						new Person { Age = 1 },
						new Person { Age = 17 },
						new Person { Age = 18 },
						new Person { Age = 19 },
						new Person { Age = 100 }
					};
					persons.Where(expr.Compile()).Should().BeEquivalentTo(persons.Where(criteria.Compile()));
				});
			// act
			service.GetAllPersonsWith18More();
			// assert
			moqRepository.VerifyAll();
		}
	}

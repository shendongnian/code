	[TestClass]
	public class AutomapperTest
	{
		[TestMethod]
		public void Test()
		{
			// arrange
			Mapper.CreateMap<AModel, A>();
			var model = new AModel { Value = 100 };
			//act
			var entity = Mapper.Map<A>(model);
			// assert
			entity.Value.Should().Be(100);
			entity.Value.Should().Be(model.Value);
		}
	}
	public class AModel
	{
		public int Value { get; set; }
	}
	public class A
	{
		public int Value { get; private set; }
	} 

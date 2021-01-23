    public void Main()
	{
		var attr1 = new MyAttribute  { Name = "Colors", PossibleValues = new List<string> { "red", "blue" } };
		var attr2 = new MyAttribute  { Name = "Sizes", PossibleValues = new List<string> { "XL", "L" } };	
		var attr3 = new MyAttribute  { Name = "Shapes", PossibleValues = new List<string> { "qube", "circle" } };	
		var attrList = new List<MyAttribute> { attr1, attr2, attr3 };
		
		var result = attrList.Skip(1).Aggregate<MyAttribute, List<Variant>>(
			new List<Variant>(attrList[0].PossibleValues.Select(s => new Variant { AttributeValues = new Dictionary<MyAttribute, string> { {attrList[0], s} } })),
			(acc, atr) =>
			{
				var aggregateResult = new List<Variant>();
				
				foreach (var createdVariant in acc)
				{
					foreach (var possibleValue in atr.PossibleValues)
					{
						var newVariant = new Variant { AttributeValues = new Dictionary<MyAttribute, string>(createdVariant.AttributeValues) };
						newVariant.AttributeValues[atr] = possibleValue;
						aggregateResult.Add(newVariant);
					}
				}
				
				return aggregateResult;
			});
	}
	public class MyAttribute
	{
		public string Name { get; set; }
		public ICollection<string> PossibleValues { get; set; }
	}
	public class Variant
	{
		public IDictionary<MyAttribute, string> AttributeValues { get; set; }
	}

    public class SampleViewModel : AsSerializeable
	{
		public string Name { get; set; }
		public List<NestedData> NestedData { get; set; }
		public SampleViewModel()
		{
			this.Name = "Serialization Demo";
			this.NestedData = Enumerable.Range(0,10).Select(i => new NestedData(i)).ToList();	
		}
	}
	
	public class NestedData
	{
		public int Id { get; set; }
		public NestedData(int id)
		{
			this.Id = id;	
		}
	}
	
	public abstract class AsSerializeable
	{
		public string ToJson()
		{
			return JsonConvert.SerializeObject(this);
		}
	}

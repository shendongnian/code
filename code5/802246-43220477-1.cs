    public class TestingObject
    {
    	public string FirstName { get; set; }
    
    	public string LastName { get; set; }
    
    	[BsonSerializer(typeof(TestingObjectTypeSerializer))]
    	public string TestingObjectType { get; set; }
    }

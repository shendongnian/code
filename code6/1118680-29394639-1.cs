    void Main()
    {
    	using( var stream = new MemoryStream() )
    	using( var reader = new StreamReader( stream ) )
    	using( var writer = new StreamWriter( stream ) )
    	using( var csv = new CsvWriter( writer ) )
    	{
    		var people = new List<Person>
    		{
    			new Person
    			{
    				Name = "Joe User",
    				Address = new Address
    				{
    					Street = "123 4th Street",
    				},
    			},
    		};
    		
    		csv.Configuration.RegisterClassMap<PersonMap>();
    		csv.WriteRecords( people );
    		writer.Flush();
    		stream.Position = 0;
    		
    		reader.ReadToEnd().Dump();
    	}
    }
    
    public class Person
    {
    	public string Name { get; set; }
    	
    	public Address Address { get; set; }
    }
    
    public class Address
    {
    	public string Street { get; set; }
    }
    
    public sealed class PersonMap : CsvClassMap<Person>
    {
    	public PersonMap()
    	{
    		AutoMap();
    		Map( m => m.Name ).Name( "Full Name" );
    	}
    }

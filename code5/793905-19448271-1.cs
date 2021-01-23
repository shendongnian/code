    using System.Xml.Linq;
    using System.Xml.Serialization;
    
    static void Main()
    {
        //create something silly to serialise:
    	var thing = new MyThing(){Name="My thing", ID=0};
    	thing.SubThings.Add(new MySubThing{ID=1});
    	thing.SubThings.Add(new MySubThing{ID=2});
    	
    	
    	//serialise to XML using an XDocument as the output 
        //(you can use any stream writer though)
        //first create the serialiser
    	var serialiser = new XmlSerializer(typeof(MyThing));
    
        //then create an XDocument and get an XmlWriter from it
    	var output= new XDocument();
    	using(var writer = output.CreateWriter())
    	{
    	   serialiser.Serialize(writer,thing);
    	}
    	Console.WriteLine(output.ToString());
    
        /*expected output:
         <MyThing xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
          <Name>My thing</Name>
          <ID>0</ID>
          <SubThings>
            <MySubThing>
              <ID>1</ID>
            </MySubThing>
            <MySubThing>
              <ID>2</ID>
            </MySubThing>
          </SubThings>
        </MyThing>
        */
    
    	//Send across network
    	//...
    	//On other end of the connection, deserialise from XML.
        //Again using XDocument as the input
        //or any Stream Reader containing the data
    	var source = output.ToString();
    	var input = XDocument.Parse(source);
    	MyThing newThing = null;
    	using (var reader = input.CreateReader())
    	{
    	  newThing = serialiser.Deserialize(reader) as MyThing;
    	}
    	if (newThing!=null)
    	{
    	   Console.WriteLine("newThing.ID={0}, It has {1} Subthings",newThing.ID,newThing.SubThings.Count);
    	}
    	else
    	{
    		//something went wrong with the de-serialisation.
    	}
    }
    
    //just some silly classes for the sample code.
    public class MyThing
    {
       public string Name{get;set;}
       public int ID{get;set;}
       public List<MySubThing> SubThings{get;set;}
       public MyThing()
       {
       		SubThings=new List<MySubThing>();
       }
    }
    
    public class MySubThing
    {
      public int ID{get;set;}
    }

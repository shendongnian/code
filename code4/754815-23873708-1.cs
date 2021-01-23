    class Program
    {
        static void Main(string[] args)
        {
            //String containing the xml array of items.
            //Note the Array Name, and the Title case on stq.
            string xml =
    @"<ArrayOfStq>
	    <stq>
		    <Name>John Doe</Name>
	    </stq>
	    <stq>
		    <Name>Martha Stewart</Name>
	    </stq>
    </ArrayOfStq>";
            List<Item> items = null;
            using (var mem = new MemoryStream(Encoding.Default.GetBytes(xml)))
            using (var stream = new StreamReader(mem))
            {
                var ser = new XmlSerializer(typeof(List<Item>)); //Deserialising to List<Item>
                items = (List<Item>)ser.Deserialize(stream);
            }
            if (items != null)
            {
                items.ForEach(I => Console.WriteLine(I.Name));
            }
            else
                Console.WriteLine("No Items Deserialised");
            
        }
    }
    
    [XmlType("stq")]
    public class Item
    {
        public string Name { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //String containing the xml array of items.
            string xml =
    @"<ArrayOfItem>
	    <Item>
		    <Name>John Doe</Name>
	    </Item>
	    <Item>
		    <Name>Martha Stewart</Name>
	    </Item>
    </ArrayOfItem>";
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
    
    public class Item
    {
        public string Name { get; set; }
    }

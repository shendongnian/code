    class Program
    {
        static void Main()
        {
            Item newItem = new Item( "http://foo", "test1", 1.0 );
            var values = new Dictionary<int,Item>();
            values.Add(1,newItem);                        
            using( StreamWriter writer = File.CreateText( "serialized.buf" ) )
            {                
                XamlServices.Save( writer, values );    
            }
            
            using( StreamReader tr = new StreamReader( "serialized.buf" ) )
            {
                Dictionary<int, Item> result = (Dictionary<int, Item>)XamlServices.Load( tr );
                //do something with array here
                Item retrievedItem = result[1];                
            }                                                         
        }
    }

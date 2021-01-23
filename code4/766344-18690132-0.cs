    class Program
    {
        static void Main()
        {
            Item newItem = new Item( "http://foo", "test1", 1.0 );
            var values = new Dictionary<int,Item>();
            values.Add(1,newItem);            
            var builder = new StringBuilder();
            XamlServices.Save( new StringWriter( builder ), values );
            var data = builder.ToString();
            Console.WriteLine( data.ToString() );
            var result = (Dictionary<int, Item>)XamlServices.Load( new StringReader( data ) );
            Console.WriteLine( result.ToString() );
        }
    }

    var rootObject = new RootObject()
    {
        cols = new List<Col>
        {
            new Col {id = "1", label = "2", type = "string"}
        },
        rows = new List<Row>()
        {
            new Row 
    		{
    		   c = new List<C> { 
                   new C { v = "a" },
                   new C { v = "b"}
               }
    		}
        }
    };

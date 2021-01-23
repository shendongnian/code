    string xml = @"<Items>
    		<Item>
    			<Name>name</Name>
    			<Detail>detail</Detail>    
    		</Item>
    	</Items>";
    
    StringBuilder sb = new StringBuilder();
    using (var p = ChoXmlReader.LoadText(xml).WithXPath("/"))
    {
    	using (var w = new ChoJSONWriter(sb)
    		.Configure(c => c.SupportMultipleContent = true)
    		)
    		w.Write(p);
    }
    
    Console.WriteLine(sb.ToString());

    var xml = @"<info>
    				<news>
    					<news name='Test 1' date='08.13.2013'/>
    					<news name='Test 2' date='08.09.2013'/>
    				</news>
    			</info>";
    			
    var doc = XElement.Parse(xml);
    
    var list = from x in doc.DescendantsAndSelf("news")
    			where !string.IsNullOrEmpty((string)x.Attribute("name"))
    			select new {name = (string)x.Attribute("name"), date = (DateTime)x.Attribute("date")};
    list.Dump();

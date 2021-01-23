    void Main()
    {
    
    	var query =
        from row in Hotels.AsEnumerable()
        group row by new
        {
    		Hotelid = row.Field<string>("Hotelid"),
    		room = row.Field<string>("room"),
    		descr = row.Field<string>("Description")        
        }
            into g
            select new XElement("Hotel",
                    new XAttribute("Hotelid", g.Key.Hotelid),
                    new XAttribute("room", g.Key.room),
                    new XAttribute("desc", g.Key.descr),
                    from row in g
    					group row by new {
    						room = row.Field<string>("Room"),
    						descr = row.Field<string>("Description"), 
    						visitor = row.Field<string>("Visitor"), 
    						name = row.Field<string>("Name")
    					} into r
                        select new XElement(
                        "Room",
                        new XAttribute("room", r.Key.room),
                        new XAttribute("desc", r.Key.descr),
                        new XAttribute("visitor", r.Key.visitor),
                        new XAttribute("name", r.Key.name),
    					new XAttribute("fineSum", r.Sum (x => x.Field<int>("Amount"))),
    					from row in r					
    					group row by new {fine = row.Field<int>("Amount")} into a
    					select new XElement("fine", a.Key.fine)
                  ));
                        
    	var document = new XDocument(new XElement("Hotels", query));					
    		
    }
    
    // Define other methods and classes here

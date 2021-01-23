    void Main()
    {
    	var query =
        from row in Hotels.AsEnumerable()
        group row by new
        {
            row.Hotelid, row.Room, row.Description
        }
            into g
            select new XElement("Hotel",
                    new XAttribute("Hotelid", g.Key.Hotelid),
                    new XAttribute("room", g.Key.Room),
                    new XAttribute("desc", g.Key.Description),
                    from row in g
    					group row by new {row.Room, row.Description, row.Visitor, row.Name} into r
                        select new XElement(
                        "Room",
                        new XAttribute("room", r.Key.Room),
                        new XAttribute("desc", r.Key.Description),
                        new XAttribute("visitor", r.Key.Visitor),
                        new XAttribute("name", r.Key.Name),
    					new XAttribute("fineSum", r.Sum (x => x.Amount)),
    					from row in r					
    					group row by new {row.Amount} into a
    					select new XElement("fine", a.Key.Amount )
                  ));
                        
    	var document = new XDocument(new XElement("Hotels", query));					
    	
    }

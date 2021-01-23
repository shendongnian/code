        var components = doc
            .Descendants("component")
            .Select(x => new Component()
            {
                Name = (string)x.Attribute("name"),
                Sample = x.Element("sample").Nodes().OfType<XComment>()
                                                                    .Select(s=>s.Value)
                                                                    .Aggregate(
                                                                        new StringBuilder(), 
                                                                        (s,i)=>s.Append(i),
                                                                        s => s.ToString()
                                                                    ),
                Data = x.Element("data").Nodes().OfType<XComment>()
                                                                    .Select(s=>s.Value)
                                                                    .Aggregate(
                                                                        new StringBuilder(), 
                                                                        (s,i)=>s.Append(i),
                                                                        s => s.ToString()
                                                                    )
            });

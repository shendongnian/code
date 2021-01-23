    var datas = xDocument.Root.Elements()
    				.Select(
    					e => e.Descendants().Count() > 0?
    					new { 
    						key = e.Descendants().Single(x => x.Name.LocalName == "SubNode1").Value,
    						value =  e.Descendants().Select(x => x.Value).ToList()
    						}:
    					new { 
    						key = e.Name.LocalName, 
    						value = new List<string>(){ e.Value } 
    						}
    				).ToDictionary( k => k.key, v => v.value );

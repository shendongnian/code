    var xml = @"<Axis>
    <Collections>
       <Collection>
           <Client>
               <Name>Client 1</Name> 
               <Value>345</Value> 
           </Client>
       </Collection>
       <Collection>
           <Client>
               <Name>Client 1</Name> 
               <Value>4532</Value> 
           </Client>
       </Collection>
       <Collection>
           <Client>
               <Name>Client 1</Name> 
               <Value>235</Value> 
           </Client>
       </Collection>
       <Collection>
           <Client>
               <Name>Client 1</Name> 
               <Value>8756</Value> 
           </Client>
       </Collection>
       <Collection>
           <Client>
               <Name>Client 1</Name> 
               <Value>76</Value> 
           </Client>
       </Collection>
    </Collections>
    <Collections>
       <Collection>
           <Client>
               <Name>Client 2</Name> 
               <Value>56</Value> 
           </Client>
       </Collection>
       <Collection>
           <Client>
               <Name>Client 2</Name> 
               <Value>43</Value> 
           </Client>
       </Collection>
       <Collection>
           <Client>
               <Name>Client 2</Name> 
               <Value>34</Value> 
           </Client>
       </Collection>
       <Collection>
           <Client>
               <Name>Client 3</Name> 
               <Value>42</Value> 
           </Client>
       </Collection>
       <Collection>
           <Client>
               <Name>Client 3</Name> 
               <Value>23</Value> 
           </Client>
       </Collection>
    </Collections>
    </Axis>";
    
    var doc = XDocument.Parse(xml);
    var dict = (from row in doc.Root.Descendants("Client")
    			let name = row.Element("Name").Value
    			let value = row.Element("Value").Value
    			group value by name into grp
    			select new { grp.Key, Values = grp.ToList() }).ToDictionary(d => d.Key, d => d.Values);
    dict.Dump();

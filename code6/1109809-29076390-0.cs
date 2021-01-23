    	var str = @"<rows>
      <row>
        <id>
          <old>2125</old>
        </id>
        <name>
          <old>test</old>
        </name>
        <amount>
          <old>62</old>
        </amount>
      </row>
    </rows>";
    
     var elements = XElement.Parse(str);
     
     var rows = elements.Elements("row");
     
      var list = new List<Row>();
      
      foreach(var row in rows)
      {
         var id = Int32.Parse(row.Element("id").Element("old").Value);
    	 
    	 var name = row.Element("name").Element("old").Value;
    	 
    	 var amount = row.Element("amount").Element("old").Value;
    	 
    	 var fields = string.Format("id|{0}^name|{1}^amount|{2}",id, name, amount);
    	 
    	 list.Add(new Row { Id = id, Fields = fields});
      }
     
     
    }

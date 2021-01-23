    var xmlNodes = elements.Nodes();
    var dbNodes = dataSetDB.Tables[0].Rows;
    
    var xmlAndDB = xmlNodes.Zip(dbNodes , (x, d) => new { xNode = x, dNode = d });
    foreach(var xd in xmlAndDB )
    {
        Console.WriteLine(xd.xNode + xd.dNode);
        string itemDB = xd.dNode[0].ToString().ToUpper();
        string itemXml = xd.xNode.ToString().ToUpper();
        
        if (itemDB == itemXml)
        {    
            //If itemDB == itemXml;
        }
        else /* if (itemDB != itemXml) */ 
        {  
            //If itemDB != itemXml;
        }
    }

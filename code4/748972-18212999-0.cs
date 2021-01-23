    using(var r = XmlReader.Create(myNetworkStream))
    {                    
        //await r.ReadAsync() only returns false at the end of the document
        //so this loop will read the whole document
        while (await r.ReadAsync()) 
        {
            switch (r.NodeType)
            {
                case XmlNodeType.Element:
                    Console.WriteLine(r.LocalName);
                    break;
                case XmlNodeType.Text:
                    Console.WriteLine(await r.GetValueAsync());
                    break;
            }
        }
    }

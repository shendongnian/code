     List<string> bananas = new List<>string();
     string contents = string.Empty;
        xmlr.ReadToFollowing("HTML");
        do
        {   
            contents = xmlr.ReadInnerXML();
            if(!string.IsNullOrEmpty(contents))
            {        
                bananas.Add(contents);  
            }
             
        }while(!string.IsNullOrEmpty(contents))

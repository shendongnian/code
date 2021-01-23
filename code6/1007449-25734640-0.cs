       while (reader.Read()){
         if (reader.IsStartElement()){
           if (reader.IsEmptyElement)
              Console.WriteLine("<{0}/>", reader.Name);
           else{

       if (line.StartsWith("1,"))
       {
           // search the second comma after  the first one....
           int pos = line.IndexOf(',', 2);
           // for simplicity, do not check if you really have found a second comma....
           string id = line.Substring(2, pos - 2);
           // Try to convert whatever is between the first comma and the second one..
           if(Int32.TryParse(id, out productID))
               Console.WriteLine("Got it:" + productID.ToString());
    
       }

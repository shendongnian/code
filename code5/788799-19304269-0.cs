    var allQuotes = responseElement.Elements("quotes").Elements("quote").ToArray();
    quotes = new Quotes[]
      {
         new Quote
         {
             ask = (string)allQuotes[0].Element("ask")
         },
         new Quote
         {
             ask = (string)allQuotes[1].Element("ask")
         },
         new Quote
         {
             ask = (string)allQuotes[2].Element("ask")
         }, ...
        // happy guessing what the last index will be..
      }

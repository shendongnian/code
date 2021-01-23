    const string text = @"[olist]
    [#]This is line 1
    [#]This is line 2
        [olist]
            [#]This is line 2.1
            [#]This is line 2.2
            [#]This is line 2.3
        [/olist]
    [#]This is line 3
    [/olist]";
    var regex = new Regex(@"^\s*\[(?<tag>[^\]]+)\](?<text>.*)$");
    var builder = new StringBuilder();
    var root = new OlElement(null);
    var currentElement = (IElement)root;
    using (var reader = new StringReader(text))
    {
      string line;
      while ((line = reader.ReadLine()) != null)
      {
        var match = regex.Match(line);
        if (match.Success)
        {
          switch (match.Groups["tag"].Value)
          {
            case "#":
              if (currentElement is OlElement)
              {
                var child = new LiElement(currentElement, match.Groups["text"].Value);
                currentElement.AddElement(child);
                currentElement = child;
                break;
              }
              if (currentElement is LiElement)
              {
                var child = new LiElement(currentElement.Parent, match.Groups["text"].Value);
                currentElement.Parent.AddElement(child);
                currentElement = child;
              }
              break;
            case "olist":
              if (currentElement == root)
              {
                break;
              }
              if (currentElement is LiElement)
              {
                var child = new OlElement(currentElement);
                currentElement.AddElement(child);
                currentElement = child;
              }
              break;
            case "/olist":
              if (currentElement is LiElement)
              {
                currentElement = currentElement.Parent.Parent;
                break;
              }
              if (currentElement is OlElement)
              {
                currentElement = currentElement.Parent;
              }
              break;
            default:
              break;
          }
        }
      }
    }
    var result = root.ToString();

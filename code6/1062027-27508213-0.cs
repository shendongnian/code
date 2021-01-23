    public interface IElement
    {
      void AddElement(IElement element);
      IElement Parent { get; }
    }
    class OlElement : IElement
    {
      public IList<LiElement> Elements { get; set; }
      public IElement Parent { get; set; }
      
      public OlElement(IElement parent)
      {
        Parent = parent;
        Elements = new List<LiElement>();
      }
      public void AddElement(IElement element)
      {
        Elements.Add((LiElement)element);
      }
      public override string ToString()
      {
        var builder = new StringBuilder();
        builder.AppendLine("<ol>");
        foreach(var child in Elements)
        {
          builder.AppendLine(child.ToString());
        }
        builder.AppendLine("</ol>");
        return builder.ToString();
      }
    }
    class LiElement : IElement
    {
      public string Text { get; set; }
      public IElement Parent { get; set; }
      public IList<OlElement> Elements { get; set; }
      public LiElement(IElement parent, string text)
      {
        Parent = parent;
        Text = text;
        Elements = new List<OlElement>();
      }
      public void AddElement(IElement element)
      {
        Elements.Add((OlElement)element);
      }
      public override string ToString()
      {
        var builder = new StringBuilder();
        builder.Append("<li>");
        builder.Append(Text);
        foreach (var child in Elements)
        {
          builder.AppendLine(child.ToString());
        }
        builder.AppendLine("</li>");
        return builder.ToString();
      }
    }

    private ArrayList elements = new ArrayList();
    public void Attach(Element element)
    {
      elements.Add(element);
    }
    public void Detach(Element element)
    {
      elements.Remove(element);
    }
    public void Accept(Visitor visitor)
    {
      foreach (Element e in elements)
      {
        e.Accept(visitor);
      }
    }
  }

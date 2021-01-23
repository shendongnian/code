    List<XElement> elements = new List<XElement>();
    while (m.ReadToFollowing("PAR"))
    {
        elements.Add(XElement.Load(m.ReadSubtree()));
    }
    Parallel.ForEach(elements, el =>
    {
    });

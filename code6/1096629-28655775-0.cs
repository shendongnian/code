    public static XElement CreateXmlElement()
    {
        var penDetails = new XElement("Pen_Details");
        penDetails.Add(new XAttribute("PenColor", PenColor.ToArgb().ToString("X")));
        penDetails.Add(new XAttribute("PenWidth", PenWidth));
        for (int i = 0; i < FreeList.Count; i++)
        {
            penDetails.Add(new XElement("Point", new XAttribute("X", FreeList[i].X), new XAttribute("Y", FreeList[i].Y)));
        };
        var shape = new XElement("Shape", new XAttribute("Name", "freeline"));
        shape.Add(penDetails);
        var shapes = new XElement("Shapes");
        shapes.Add(shape);
        return shapes;
    }

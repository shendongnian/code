    var xDoc = XDocument.Load("Input.xml");
    Func<XElement, List<Control>> childControlsQuery = null;
    childControlsQuery =
        x => (from c in x.Elements("control")
              select new Control
              {
                  Id = (string)c.Attribute("id"),
                  ControlType = (string)c.Attribute("controltype"),
                  SearchProperties = (string)c.Attribute("searchproperties"),
                  ChildrenControl = childControlsQuery(c.Element("childControls") ?? new XElement("childControls"))
              }).ToList();
    var controls = childControlsQuery(xDoc.Root);

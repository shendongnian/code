    DateTime start = DateTime.Today;
    XYDiagram diagram = (XYDiagram)chartEditor.Diagram;
    
    diagram.AxisX.WholeRange.Auto = false;
    diagram.AxisX.VisualRange.SetMinMaxValues(start.AddHours(0), start.AddHours(24));

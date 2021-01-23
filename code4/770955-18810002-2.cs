    ShapeProperties shapeProperties1 = new ShapeProperties();
    
    D.Transform2D transform2D1 = new D.Transform2D();
    D.Offset offset1 = new D.Offset() { X = x, Y = y };
    D.Extents extents1 = new D.Extents() { Cx = width, Cy = heigth };
    
    transform2D1.Append(offset1);
    transform2D1.Append(extents1);
    
    D.PresetGeometry presetGeometry1 = new D.PresetGeometry() { Preset = shapeType };
    D.AdjustValueList adjustValueList1 = new D.AdjustValueList();
    
    presetGeometry1.Append(adjustValueList1);
    
    D.SolidFill solidFill1 = new D.SolidFill();
    D.RgbColorModelHex rgbColorModelHex1 = new D.RgbColorModelHex() { Val = rgbColorHex };
    
    solidFill1.Append(rgbColorModelHex1);
    
    D.Outline outline1 = new D.Outline() { Width = 12700 };
    
    D.SolidFill solidFill2 = new D.SolidFill();
    D.SchemeColor schemeColor1 = new D.SchemeColor() { Val = D.SchemeColorValues.Text1 };
    
    solidFill2.Append(schemeColor1);
    
    outline1.Append(solidFill2);
    
    shapeProperties1.Append(transform2D1);
    shapeProperties1.Append(presetGeometry1);
    shapeProperties1.Append(solidFill1);
    shapeProperties1.Append(outline1);

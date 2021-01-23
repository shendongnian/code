    ShapeStyle shapeStyle1 = new ShapeStyle();
    
    D.LineReference lineReference1 = new D.LineReference() { Index = (UInt32Value)2U };
    
    D.SchemeColor schemeColor2 = new D.SchemeColor() { Val = D.SchemeColorValues.Accent1 };
    D.Shade shade1 = new D.Shade() { Val = 50000 };
    
    schemeColor2.Append(shade1);
    
    lineReference1.Append(schemeColor2);
    
    D.FillReference fillReference1 = new D.FillReference() { Index = (UInt32Value)1U };
    D.SchemeColor schemeColor3 = new D.SchemeColor() { Val = D.SchemeColorValues.Accent1 };
    
    fillReference1.Append(schemeColor3);
    
    D.EffectReference effectReference1 = new D.EffectReference() { Index = (UInt32Value)0U };
    D.SchemeColor schemeColor4 = new D.SchemeColor() { Val = D.SchemeColorValues.Accent1 };
    
    effectReference1.Append(schemeColor4);
    
    D.FontReference fontReference1 = new D.FontReference() { Index = D.FontCollectionIndexValues.Minor };
    D.SchemeColor schemeColor5 = new D.SchemeColor() { Val = D.SchemeColorValues.Light1 };
    
    fontReference1.Append(schemeColor5);
    
    shapeStyle1.Append(lineReference1);
    shapeStyle1.Append(fillReference1);
    shapeStyle1.Append(effectReference1);
    shapeStyle1.Append(fontReference1);

    const string dwgPath = @"C:\Test.dwg";
    var acadDoc = acadDocs.Open(dwgPath);
    foreach (AcadEntity ent in acadDoc.ModelSpace)
    {
        var block = ent as AcadBlockReference;
        if (block == null) continue;
        {
            if (!block.Name.Equals("BlockName", StringComparison.CurrentCultureIgnoreCase)) continue;
            var newColor = acadApp.GetInterfaceObject("AutoCAD.AcCmColor.18") as AcadAcCmColor;
            if (newColor != null)
            {
                newColor.ColorIndex = AcColor.acMagenta;
                block.TrueColor = newColor;
            }
        }
    }

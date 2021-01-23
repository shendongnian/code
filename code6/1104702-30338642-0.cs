            Autodesk.Revit.DB.Options opt = new Options();
            Autodesk.Revit.DB.GeometryElement geomElem = wall.get_Geometry(opt);
            ElementId m = new ElementId(11534);
            foreach (GeometryObject geomObj in geomElem)
            {
                if (geomObj is Face)
                {
                    Face f = geomObj as Face;
                    doc.Paint(wall.Id, f, m);
                }
            }

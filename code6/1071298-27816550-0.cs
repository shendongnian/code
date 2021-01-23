     internal class FooItem  
        {
            public FooItem(XElement xElement)
            {
                float yvar = -1;
                int zvar = -1;
                if (xElement.Element("X") == null) X = "";
                else X = xElement.Element("X").Value;
    
                if (xElement.Element("Y") == null) Y = yvar;
                else
                {
                    if (float.TryParse(xElement.Element("Y").Value, out yvar))
                        Y = yvar;
                }
    
                if (xElement.Element("Z") == null) Z = zvar;
                else
                {
                    if (int.TryParse(xElement.Element("Z").Value, out zvar))
                        Z = zvar;
                }
    
            }
    
            public string X { get; set; }
            public float Y { get; set; }
            public int Z { get; set; }
        }

     List<OpenXmlElement> elements = new List<OpenXmlElement>();
            elements.Add(new P.NonVisualGraphicFrameProperties
                (new P.NonVisualDrawingProperties() { Id = 1, Name = "xyz" }, new P.NonVisualGraphicFrameDrawingProperties(),new ApplicationNonVisualDrawingProperties()));
          
           
         
            P.GraphicFrame graphicFrame = tableSlidePart.Slide.CommonSlideData.ShapeTree.AppendChild(new P.GraphicFrame(elements));

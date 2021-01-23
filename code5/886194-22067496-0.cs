    //Loop through all slides
    foreach (Slide exportSlide in newPresentation.Slides)
    {
        //Loop through all shapes
        foreach (Shape shape in exportSlide.Shapes)
        {
            //If the shape is a chart
            if (shape.HasChart == MsoTriState.msoTrue)
            {
                //Copy to clipboard
                shape.Copy();
                //Paste as an image
                var newShape = exportSlide.Shapes.PasteSpecial(PpPasteDataType.ppPastePNG);
                //Move back to chart position
                newShape.Left = shape.Left;
                newShape.Top = shape.Top;
                //Delete the original shape
                shape.Delete();
            }
        }
    }

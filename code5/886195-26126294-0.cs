    //Open the slides presentation
    var pres = _application.Presentations.Open2007(item.PresentationPath,
        Microsoft.Office.Core.MsoTriState.msoFalse,
        Microsoft.Office.Core.MsoTriState.msoFalse,
        Microsoft.Office.Core.MsoTriState.msoFalse,
        Microsoft.Office.Core.MsoTriState.msoFalse);
     //For slide ranges
     foreach (var i in range)
     {
         //Get the old slide
         var oldSlide = pres.Slides[i];
         oldSlide.Copy();
         //Paste the slide into the new presentation
         var newSlide = newPresentation.Slides.Paste(totalSlides + 1);
         newSlide.Design = oldSlide.Design;
         newSlide.ColorScheme = oldSlide.ColorScheme;
         /* The shapes haven't retained their content because we are not in slide...
         view because there is no window. */
                        
         //Delete all the shapes that were just pasted in because of the slide paste.
         for (int k = newSlide.Shapes.Count; k > 0; k--)
         {
             newSlide.Shapes[k].Delete();
         }
         //Put in our shapes
         //Loop forwards, because we arn't editing the list and forward is required to
         //maintain the zorder we want on some slides.
         for (int j = 1; j <= oldSlide.Shapes.Count; j++)
         {
             var oldShape = oldSlide.Shapes[j];
             oldShape.Copy();
             //Paste Put it where it should be on the page
             /* This is a special case where the client have put textboxes in the
             Powerpoint and rotated throwing off the position, so we need treat as rotated
             shapes to make it right. */
             if (oldShape.HasTextFrame == MsoTriState.msoTrue && Math.Abs(oldShape.Rotation) > 0)
             {
                 //Paste as a shape because it's a more complex object
                 //set ALL THE PROPERTIES just in case.
                 var newShape = newSlide.Shapes.PasteSpecial(PpPasteDataType.ppPasteShape);
                 newShape.Rotation = oldShape.Rotation;
                 newShape.Top = oldShape.Top;
                 newShape.Left = oldShape.Left;
                 newShape.TextFrame.Orientation = oldShape.TextFrame.Orientation;
                 newShape.TextFrame.WordWrap = oldShape.TextFrame.WordWrap;
                 newShape.TextFrame.VerticalAnchor = oldShape.TextFrame.VerticalAnchor;
             }
             else // Act normally
             {
                 //Paste the old shape into the new slide as an image to ENSURE FORMATTING
                 var newShape = newSlide.Shapes.PasteSpecial(PpPasteDataType.ppPastePNG);
                 newShape.Top = oldShape.Top;
                 newShape.Left = oldShape.Left;
             }
         }
         totalSlides += ((item.EndIndex - item.StartIndex) + 1);
         pres.Close();
     }

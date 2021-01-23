    public void DrawLineOnImage(Image image, Color lineColor, float lineWeight,
                                System.Drawing.Point lineStart, System.Drawing.Point lineEnd)
    {
       // This methods draws a line on the image given as parameter
    
       try
       {
          // Check the parameters
          if (image == null || lineColor == null || lineStart == null || lineWeight == null || lineWeight <= 0) { MessageBox.Show("Invalid parameters!"); return; }
          // Draw a line on the image
          using (Graphics g = Graphics.FromImage(image))
          using (Pen pen = new Pen(lineColor, lineWeight))
          {
             // Draw the line
             g.DrawLine(pen, lineStart, lineEnd);
          }
       }
    
       catch (Exception ex) { MessageBox.Show(ex.Message); }
    }

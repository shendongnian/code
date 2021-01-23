        // StringFormat created using GenericTypographic
        using (StringFormat stringFormat = new StringFormat(StringFormat.GenericTypographic))
        {
            CharacterRange[] charRange = { new CharacterRange(0, test.Length) };
            stringFormat.SetMeasurableCharacterRanges(charRange);
            Region[] sr = g.MeasureCharacterRanges(test, font, layout, stringFormat);
    
            RectangleF rectangle = sr[0].GetBounds(g);
    
            PointF location = new PointF((this.ClientRectangle.Width - rectangle.Width) / 2.0f, ((this.ClientRectangle.Height - rectangle.Height) / 2.0F));
            rectangle.Location = location;
    
            using (SolidBrush brush = new SolidBrush(Color.Black))
            {
                // Now passing in stringFormat
                g.DrawString(test, font, brush, rectangle.Location, stringFormat);
            }
            g.DrawRectangle(Pens.Red, Rectangle.Round(rectangle));
    
        }
               

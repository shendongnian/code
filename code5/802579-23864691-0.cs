        // You hand this the text that you need to fit inside some
        // available room, and the font you'd like to use.
        // If the text fits nothing changes
        // If the text does not fit then it is reduced in size to
        // make it fit.
        // PreferedFont is the Font that you wish to apply
        // FontUnit is there because the default font unit is not
        // always the one you use, and it is info required in the
        // constructor for the new Font.
        public static void FindGoodFont(Graphics Graf, string sStringToFit,
                                        Size TextRoomAvail, 
                                        ref Font FontToUse,
                                        GraphicsUnit FontUnit)
        {
            // Find out what the current size of the string in this font is
            SizeF RealSize = Graf.MeasureString(sStringToFit, FontToUse);
            Debug.WriteLine("big string is {0}, orig size = {1},{2}",
                             sStringToFit, RealSize.Width, RealSize.Height);
            if ((RealSize.Width <= TextRoomAvail.Width) && (RealSize.Height <= TextRoomAvail.Height))
            {
                Debug.WriteLine("The space is big enough already");
                // The current font is fine...
                return;
            }
            // Either width or height is too big...
            // Usually either the height ratio or the width ratio
            // will be less than 1. Work them out...
            float HeightScaleRatio = TextRoomAvail.Height / RealSize.Height;
            float WidthScaleRatio = TextRoomAvail.Width / RealSize.Width;
            // We'll scale the font by the one which is furthest out of range...
            float ScaleRatio = (HeightScaleRatio < WidthScaleRatio) ? ScaleRatio = HeightScaleRatio : ScaleRatio = WidthScaleRatio;
            float ScaleFontSize = FontToUse.Size * ScaleRatio;
            Debug.WriteLine("Resizing with scales {0},{1} chose {2}",
                             HeightScaleRatio, WidthScaleRatio, ScaleRatio);
            Debug.WriteLine("Old font size was {0}, new={1} ",FontToUse.Size,ScaleFontSize);
            // Retain whatever the style was in the old font...
            FontStyle OldFontStyle = FontToUse.Style;
            // Get rid of the old non working font...
            FontToUse.Dispose();
            // Tell the caller to use this newer smaller font.
            FontToUse = new Font(FontToUse.FontFamily,
                                    ScaleFontSize,
                                    OldFontStyle,
                                    FontUnit);
        }

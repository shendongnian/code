    public static Font GetAdjustedFont(Graphics graphic, string str, Font originalFont, Size containerSize)
        {
            // We utilize MeasureString which we get via a control instance           
            for (int adjustedSize = (int)originalFont.Size; adjustedSize >= 1; adjustedSize--)
            {
                var testFont = new Font(originalFont.Name, adjustedSize, originalFont.Style, GraphicsUnit.Pixel);
                // Test the string with the new size
                var adjustedSizeNew = graphic.MeasureString(str, testFont, containerSize.Width);
                if (containerSize.Height > Convert.ToInt32(adjustedSizeNew.Height))
                {
                    // Good font, return it
                    return testFont;
                }
            }
            return new Font(originalFont.Name, 1, originalFont.Style, GraphicsUnit.Pixel);
        }

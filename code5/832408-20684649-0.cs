        string fontsFolder = string.Format(CultureInfo.InvariantCulture, "{0}\\Fonts", Environment.GetEnvironmentVariable("SystemRoot"));
        FontFactory.RegisterDirectory(fontsFolder);
        BaseFont myBaseFont = FontFactory.GetFont(mySysDrawFont.OriginalFontName, mySysDrawFont.Size, ConvertFontStyle(mySysDrawFont.Style)).BaseFont;
        private static int ConvertFontStyle(FontStyle fontStyle)
        {
            switch (fontStyle)
            {
                case FontStyle.Regular:
                    return Font.NORMAL;
                case FontStyle.Bold:
                    return Font.BOLD;
                case FontStyle.Italic:
                    return Font.ITALIC;
                case FontStyle.Underline:
                    return Font.UNDERLINE;
                case FontStyle.Strikeout:
                    return Font.STRIKETHRU;
                default:
                    return Font.UNDEFINED;
            }
        }

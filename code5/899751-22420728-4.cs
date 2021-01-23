        private void View_Loaded(object sender, RoutedEventArgs e)
        {
            var listView = (sender as ListView);
            var gridView = (listView.View as GridView);
            if (listView == null || gridView == null)
            {
                return;
            }
            gridView.Columns[0].Width = MeasureText(dataList.OrderByDescending(
                                            s => s.Length).First(),
                                            listView.FontFamily, 
                                            listView.FontStyle, 
                                            listView.FontWeight, 
                                            listView.FontStretch, 
                                            listView.FontSize).Width;
        }
        public static System.Windows.Size MeasureTextSize(string text, 
                                              System.Windows.Media.FontFamily fontFamily, 
                                              System.Windows.FontStyle fontStyle, 
                                              FontWeight fontWeight, 
                                              FontStretch fontStretch, double fontSize)
        {
            FormattedText ft = new FormattedText(text,
                                                 CultureInfo.CurrentCulture,
                                                 FlowDirection.LeftToRight,
                                                 new Typeface(fontFamily, fontStyle, 
                                                     fontWeight, fontStretch),
                                                     fontSize,
                                                     System.Windows.Media.Brushes.Black);
            return new System.Windows.Size(ft.Width, ft.Height);
        }
        public static System.Windows.Size MeasureText(string text, 
                                              System.Windows.Media.FontFamily fontFamily, 
                                              System.Windows.FontStyle fontStyle, 
                                              FontWeight fontWeight, 
                                              FontStretch fontStretch, double fontSize)
        {
            Typeface typeface = new Typeface(fontFamily, fontStyle, fontWeight,
                                             fontStretch);
            GlyphTypeface glyphTypeface;
            if (!typeface.TryGetGlyphTypeface(out glyphTypeface))
            {
                return MeasureTextSize(text, fontFamily, fontStyle, fontWeight, 
                                       fontStretch, fontSize);
            }
            double totalWidth = 0;
            double height = 0;
            for (int n = 0; n < text.Length; n++)
            {
                ushort glyphIndex = glyphTypeface.CharacterToGlyphMap[text[n]];
                double width = glyphTypeface.AdvanceWidths[glyphIndex] * fontSize;
                double glyphHeight = glyphTypeface.AdvanceHeights[glyphIndex] * fontSize;
                if (glyphHeight > height)
                {
                    height = glyphHeight;
                }
                totalWidth += width;
            }
            return new System.Windows.Size(totalWidth, height);
        }

     public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var stringviewmodel = value as StringModel;
            if (stringviewmodel != null)
            {
                stringviewmodel.ft = new FormattedText(
               stringviewmodel.text,
               CultureInfo.CurrentCulture,
               FlowDirection.LeftToRight,
               new Typeface(new FontFamily("Segoe Script"), FontStyles.Italic, FontWeights.Normal, FontStretches.Normal),
               stringviewmodel.emSize,
               stringviewmodel.color);
                stringviewmodel.ft.TextAlignment = TextAlignment.Left;
                // apply special styles
                Image myImage = new Image();
                DrawingVisual drawingVisual = new DrawingVisual();
                DrawingContext dc = drawingVisual.RenderOpen();
                dc.DrawText(stringviewmodel.ft, stringviewmodel.topleft);
                dc.Close();
                RenderTargetBitmap bmp = new RenderTargetBitmap(180, 180, 120, 96, PixelFormats.Pbgra32);
                bmp.Render(drawingVisual);
                myImage.Source = bmp;
                return myImage;
            }
            else
            {
                return null;
            }
        }

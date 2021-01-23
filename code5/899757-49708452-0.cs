    /// <summary>
    /// Iterates a collection of items to calculate the maximum text width of those items.
    /// Items can either be primitive types and strings or objects with a property that is
    /// a primitive type or string.
    /// </summary>
    public sealed class ItemsToWidthConverter : IMultiValueConverter
    {
        //Constants for array indexes.
        private const int FONTFAMILY_ID = 0;
        private const int FONTSTYLE_ID = 1;
        private const int FONTWEIGHT_ID = 2;
        private const int FONTSTRETCH_ID = 3;
        private const int FONTSIZE_ID = 4;
        private const int FOREGROUND_ID = 5;
        private const int MINWIDTH_ID = 6;
        private const int MAXWIDTH_ID = 7;
        private const int ICOLLECTION_ID = 8;
        private const int PARAMETERPROPERTY_ID = 0;
        private const int PARAMETERGAP_ID = 1;
        /// <summary>
        /// Converts collection items to a width.
        /// Parameter[0] is the property name of an object. If no property name is needed, pass in null.
        /// Parameter[1] is the padding to be added to the calculated width. If no padding is needed, pass in a Thickness of 0.
        /// Note: a ListViewItem has default padding of {12,0,12,0}. A GridViewColumn has default padding of {6,0,6,0}.
        /// </summary>
        /// <param name="values">Array of 9 objects {FontFamily, FontStyle, FontWeight, FontStretch, double [FontSize], Brush, double [MinWidth], double [MaxWidth], ICollection}</param>
        /// <param name="targetType">Double</param>
        /// <param name="parameter">Array of 2 objects {string [Property Name], Thickness}</param>
        /// <param name="culture">Desired CultureInfo</param>
        /// <returns>Width of widest item including padding or Nan if none is calculated.</returns>
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            // Throw error if passed parameters are incorrect.
            if (values.Length != 9) throw new Exception("Incorrect number of items passed in 'values'.");
            if (!(parameter.GetType().IsArray)) throw new Exception("'Parameter' must be an array.");
            var prm = (object[])parameter;
            if (prm.Length !=2) throw new Exception("Incorrect number of items passed in 'parameter'.");
            if (prm[PARAMETERPROPERTY_ID] != null && !(prm[PARAMETERPROPERTY_ID] is string property)) throw new Exception("'Parameter['" + PARAMETERPROPERTY_ID + "]' is neither null nor of type 'string'.");
            if (!(prm[PARAMETERGAP_ID] is Thickness margin)) throw new Exception("'Parameter['" + PARAMETERGAP_ID + "]' is not of type 'Thickness'.");
            if (values[ICOLLECTION_ID] == null) return double.NaN;
            if (!(values[FONTFAMILY_ID] is FontFamily family)) throw new Exception("'Value['" + FONTFAMILY_ID + "]' is not of type 'FontFamily'.");
            if (!(values[FONTSTYLE_ID] is FontStyle style)) throw new Exception("'Value['" + FONTSTYLE_ID + "]' is not of type 'FontStyle'.");
            if (!(values[FONTWEIGHT_ID] is FontWeight weight)) throw new Exception("'Value['" + FONTWEIGHT_ID + "]' is not of type 'FontWeight'.");
            if (!(values[FONTSTRETCH_ID] is FontStretch stretch)) throw new Exception("'Value['" + FONTSTRETCH_ID + "]' is not of type 'FontStretch'.");
            if (!(values[FONTSIZE_ID] is double size)) throw new Exception("'Value['" + FONTSIZE_ID + "]' is not of type 'double'.");
            if (!(values[FOREGROUND_ID] is Brush foreground)) throw new Exception("'Value['" + FOREGROUND_ID + "]' is not of type 'Brush'.");
            if (!(values[MINWIDTH_ID] is double minWidth)) throw new Exception("'Value['" + MINWIDTH_ID + "]' is not of type 'double'.");
            if (!(values[MAXWIDTH_ID] is double maxWidth)) throw new Exception("'Value['" + MAXWIDTH_ID + "]' is not of type 'double'.");
            if (!(values[ICOLLECTION_ID] is ICollection col)) throw new Exception("'Value['" + ICOLLECTION_ID + "]' is not of type 'ICollection'.");
            // Conver font properties to a typeface.
            var typeFace = new Typeface(family, style, weight, stretch);
            // Initialise the max_width variable at 0.
            var widest = 0.0;
            foreach (var item in col)
            {
                // If property parameter is null, assume the ICollection contains primitives or strings.
                if (prm[PARAMETERPROPERTY_ID] == null)
                {
                    if (item.GetType().IsPrimitive || item is string)
                    {
                        var text = new FormattedText(item.ToString(),
                                                     culture,
                                                     FlowDirection.LeftToRight,
                                                     typeFace,
                                                     size,
                                                     foreground,
                                                     null,
                                                     TextFormattingMode.Ideal);
                        if (text.WidthIncludingTrailingWhitespace > widest)
                            widest = text.WidthIncludingTrailingWhitespace;
                    }
                }
                else
                // Property parameter contains a string, so assume ICollection is an object
                // and use reflection to get property value.
                {
                    if (item.GetType().GetProperty(prm[PARAMETERPROPERTY_ID].ToString()) != null)
                    {
                        var propertyValue = item.GetType().GetProperty(prm[PARAMETERPROPERTY_ID].ToString()).GetValue(item);
                        if (propertyValue.GetType().IsPrimitive || propertyValue is string)
                        {
                            var text = new FormattedText(propertyValue.ToString(),
                                                         culture,
                                                         FlowDirection.LeftToRight,
                                                         typeFace,
                                                         size,
                                                         foreground,
                                                         null,
                                                         TextFormattingMode.Display);
                            if (text.WidthIncludingTrailingWhitespace > widest)
                                widest = text.WidthIncludingTrailingWhitespace;
                        }
                    }
                }
            }
            // If no width could be calculated, return Nan which sets the width to 'Automatic'
            if (widest == 0) return double.NaN;
            // Add the left and right thickness values to the calculated width and
            // check result is within min and max values.
            {
                widest += ((Thickness)prm[PARAMETERGAP_ID]).Left + ((Thickness)prm[PARAMETERGAP_ID]).Right;
                if (widest < minWidth || widest > maxWidth) return double.NaN;
                return widest;
            }
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

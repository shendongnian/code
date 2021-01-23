        public object Convert(object value, Type targetType, object parameter, string language)
        {
            Visibility visibilty = Visibility.Visible;
            string paramType = parameter as string;
            bool isVisible = (bool)value;
            if (paramType == "direct")
            {
                visibilty = (isVisible == false) ? Visibility.Collapsed : Visibility.Visible;
            }
            else if (paramType == "invert")
            {
                visibilty = isVisible ? Visibility.Collapsed : Visibility.Visible;
            }
            return visibilty;
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return null;
        }
        #endregion
    }

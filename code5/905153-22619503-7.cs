    public class BackgroundConvertor: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            SolidColorBrush solidColorBrush = null;
            if (value != null)
            {
                Answer answer = (Answer)value ;
                if (parameter != null)
                {
                    if (answer.IsCorrect == 1 && parameter.ToString() == "0")
                    {
                        solidColorBrush = new SolidColorBrush(Color.FromArgb((byte)255, (byte)201, (byte)235, (byte)242)); //blue color                                                       
                    }
                    else if (answer.IsCorrect == 1 && parameter.ToString() == "1")  
                    {
                        solidColorBrush = new SolidColorBrush(Color.FromArgb((byte)255, (byte)201, (byte)242, (byte)169));//green color                                                        
                    }
                    else
                    {
                        solidColorBrush = new SolidColorBrush(Color.FromArgb((byte)255, (byte)227, (byte)232, (byte)240));//Grey color.
                    }
                }
                else if (answer.IsCorrect == 1)
                {
                    solidColorBrush = new SolidColorBrush(Color.FromArgb((byte)255, (byte)201, (byte)242, (byte)169));//green color  
                }
                else
                {
                    solidColorBrush = new SolidColorBrush(Color.FromArgb((byte)255, (byte)227, (byte)232, (byte)240));//Grey color.
                }
            }
            return solidColorBrush;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

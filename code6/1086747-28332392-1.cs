    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace DilbertDownloader
    {
        public class TextVerticalConverter : System.Windows.Data.IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                if (!(value is string)) return value;
                var converted = "";
                foreach (var character in (string)value)
                {
                    //If the character is a space, add another new line 
                    //so we get a vertical 'space'
                    if (character == ' ') {  
                        converted += '\n';
                        continue;
                    }
                    //If there's a character before this one, add a newline before our
                    //current character
                    if (!string.IsNullOrEmpty(converted))
                        converted += "\n";
                    converted += character;
                }
                return converted; 
            }
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                //Not really worried about this at the moment
                throw new NotImplementedException();
            }
        }
    }

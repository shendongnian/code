    using System.Globalization;
    using System.Windows.Media;
    string stringValue = ...
    ImageSourceConverter converter = new ImageSourceConverter();
    ImageSource imageSource = converter.ConvertFrom(
        null, CultureInfo.CurrentUICulture, stringValue);

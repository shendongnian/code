    public class ByteToBitmapValueConverter : MvxValueConverter<byte[], Bitmap>
        {
            protected override Bitmap Convert(byte[] value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                return BitmapFactory.DecodeByteArray(value, 0, value.Length);
            }
        }

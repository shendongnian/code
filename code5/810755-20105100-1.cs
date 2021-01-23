    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;
    namespace So19902960WpfMenuItemIconGeometry
    {
        public partial class MainWindow
        {
            public MainWindow ()
            {
                InitializeComponent();
            }
        }
        public class StaticResourceConverter : IValueConverter
        {
            public object Convert (object value, Type targetType, object parameter, CultureInfo culture)
            {
                if (value == DependencyProperty.UnsetValue || value == null)
                    return DependencyProperty.UnsetValue;
                return Application.Current.MainWindow.Resources[value];
            }
            public object ConvertBack (object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotSupportedException();
            }
        }
    }

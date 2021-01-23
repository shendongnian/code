    using System;
    using System.Windows;
    using System.Windows.Data;
    using System.Windows.Markup;
    
    namespace flipx
    {
        public class BooleanToScaleConverter : MarkupExtension, IValueConverter
        {
            static BooleanToScaleConverter converter;
    
            public BooleanToScaleConverter() { }
    
            public override object ProvideValue(IServiceProvider serviceProvider)
            {
                if (converter == null) converter = new BooleanToScaleConverter();
                return converter;
            }
    
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                bool boolValue = (bool)value;
                return boolValue ? -1 : 1;
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    
        public partial class MainWindow : Window
        {
            public double ScaleFactor
            {
                get { return (double)GetValue(ScaleFactorProperty); }
                set { SetValue(ScaleFactorProperty, value); }
            }
            public static readonly DependencyProperty ScaleFactorProperty =
                DependencyProperty.Register("ScaleFactor", typeof(double), typeof(MainWindow), new PropertyMetadata(1d));
    
            public bool FlipX
            {
                get { return (bool)GetValue(FlipXProperty); }
                set { SetValue(FlipXProperty, value); }
            }
            public static readonly DependencyProperty FlipXProperty =
                DependencyProperty.Register("FlipX", typeof(bool), typeof(MainWindow), new PropertyMetadata(false));
    
            public bool FlipY
            {
                get { return (bool)GetValue(FlipYProperty); }
                set { SetValue(FlipYProperty, value); }
            }        
            public static readonly DependencyProperty FlipYProperty =
                DependencyProperty.Register("FlipY", typeof(bool), typeof(MainWindow), new PropertyMetadata(false));
            
            public MainWindow()
            {
                InitializeComponent();
            }
        }
    }

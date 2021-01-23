	////DependencyProperty
	public string SelectedTextBlockName
    {
        get { return (string)GetValue(SelectedTextBlockNameProperty); }
        set { SetValue(SelectedTextBlockNameProperty, value); }
    }
    // Using a DependencyProperty as the backing store for SelectedTextBlock.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty SelectedTextBlockNameProperty =
        DependencyProperty.Register("SelectedTextBlockName", typeof(string), typeof(Class_Name), new PropertyMetadata(null));
	.......
	
	private void TextBlockMouseDownEvent(object sender, MouseButtonEventArgs e)
    {
        TextBlock txtBlock = sender as TextBlock;
        if (txtBlock != null)
        {
            SelectedTextBlockName = txtBlock.Name;
        }
    }
	
	.......
	
	public class BackgroundConverter : IMultiValueConverter
    {
        /// <summary>
        /// Values[0] = Name of TextBlock
        /// values[1] = SelectedTextBlockName
        /// If matches then it is selected
        /// </summary>
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values[0] != null && values[1] != null && values[0].ToString() == values[1].ToString())
                return new SolidColorBrush(Colors.Blue);
            return new SolidColorBrush(Colors.White);
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
	

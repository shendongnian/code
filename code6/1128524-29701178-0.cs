    <Window.Resources>
        <local:TextBlockConverter x:Key="Conv"/>
    </Window.Resources>
    <Label Content="{Binding senselist,Converter={StaticResource Conv}}"></Label>
    class TextBlockConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            TextBlock txt = new TextBlock();
            string str = (string)value;
            string[] strList = str.Split('|');
            Run run1 = new Run(strList[0]);
            run1.FontWeight = FontWeights.Bold;
            Run run2 = new Run(strList[1]);
            Hyperlink hyp = new Hyperlink(run2);
            txt.Inlines.Add(run1);
            txt.Inlines.Add(hyp);
            return txt;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
     senselist = "sense_list" + "|" + "gramGroup";

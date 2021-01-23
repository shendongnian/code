        public class IsSelectedChoiceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool _check = false;
            if (value == null)
                return false;
            Item currentItem = (Item)value;
            if (currentItem.ChoicesinItem.Count == 0)
                _check = false;
            foreach (var _choicesinItem in currentItem.ChoicesinItem)
            {
                if (currentItem.CurrentChoiceId == _choicesinItem.ChoicesId)
                    _check = true;
            }
            return _check;
        }

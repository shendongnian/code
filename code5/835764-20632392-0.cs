    public void MakeArrowListConverter : IValueConverter
    {
      public double ArrowHeight {get;set;}
      public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
      {
         var verticalSpace = (double) value;
         int numberOfArrows = (int)(verticalSpace/ArrowHeight);
         return Enumerable.Range(0, numberOfArrows);
      }
    }

    [ValueConversion(typeof(decimal), typeof(Brush))]
    public class PriceToColorConverter : IValueConverer
    {
       public object Convert(object value, Type target)
       {
          decimal price;
          decimal.Parse(value.ToString(), price);
          return (price > 0 ? Brushes.Green : Brushes.Red);
       }
    }

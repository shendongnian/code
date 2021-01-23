c#
   public sealed class MyConfiguration
   {
      #region Singleton
      private static readonly Lazy<MyConfiguration> lazy = new Lazy<MyConfiguration>(() => new MyConfiguration());
      public static MyConfiguration Instance { get { return lazy.Value; } }
      private MyConfiguration() {}
      #endregion
      
      public int NumberOfDecimals { get; set; }
   }
MyConverters.cs
c#
   /// <summary>
   /// Formats a double for display in list
   /// </summary>
   public class DoubleConverter : IValueConverter
   {
      public object Convert(object o, Type type, object parameter, CultureInfo culture)
      {
         //--> Initializations
         IConvertible iconvertible__my_number = o as IConvertible;
         IConvertible iconvertible__number_of_decimals = parameter as IConvertible;
         //--> Read the value
         Double double__my_number = iconvertible__my_number.ToDouble(null);
         //--> Read the number of decimals       
         int number_of_decimals = MyConfiguration.Instance.NumberOfDecimals; // get configuration
         if (parameter != null)  // the value can be overwritten by specifying a Converter Parameter
         {
            number_of_decimals = iconvertible__number_of_decimals.ToInt32(null);
         }
            
         //--> Apply conversion
         string string__number = (Double.IsNaN(double__number)) ? "" : (number_of_decimals>=0) ? Math.Round(double__my_number, number_of_decimals).ToString(): double__my_number.ToString();
         return string__number;
      }
      public object ConvertBack(object o, Type type, object parameter, CultureInfo culture)
      {
         throw new NotSupportedException();
      }
   }
NumberOfDecimals has to be set before calling the XALM form. 
c#
MyConfiguration.Instance.NumberOfDecimals = user_defined_value;

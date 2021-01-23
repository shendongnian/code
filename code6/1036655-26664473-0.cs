    /// <summary>
    ///     A way to convert the color of text based upon maintenance required
    /// </summary>
    public class MaintenenceColorConverter : IValueConverter
    {
        #region Properties
        // Properties
        public Color NormalColor { get; set; }
        public Color NoMaintenanceRequiredColor { get; set; }
        #endregion
        /// <summary>
        ///     DEFAULT CONSTRUCTOR
        /// </summary>
        public MaintenenceColorConverter() { }
        /// <summary>
        ///     Convert the color of the text based upon maintenance required
        /// </summary>
        /// <returns>
        ///     The appropriate color property
        /// </returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value.ToString() == "No Maintenance Required") return NoMaintenanceRequiredColor.ToString();
            return NormalColor.ToString();
        }
        /// <summary>
        ///     Not used: NECESSARY FOR IMPLEMENTATION
        /// </summary>
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
        }
    }

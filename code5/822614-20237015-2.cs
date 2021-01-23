    public interface IUIDialogWindowService
    {
        ///<summary>
        /// Zeigt ein Dialog an.
        ///</summary>
        ///<param name="titel">Titel für den Dialog</param>
        ///<param name="datacontext">DataContext für den Dialog</param>
        ///<returns>true wenn DialogResult=true, ansonsten false</returns>
        bool? ShowDialog(string titel, object datacontext);
        ///<summary>
        /// Zeigt ein Dialog an.
        ///</summary>
        ///<param name="titel">Titel für den Dialog</param>
        ///<param name="datacontext">DataContext für den Dialog</param>
        ///<param name="minHeigth">Minimum Height</param>
        ///<param name="minWidth">Minimum Width</param>
        ///<param name="maxHeigth">Maximum Height</param>
        ///<param name="maxWidth">Maximum Width</param>
        ///<returns>true wenn DialogResult=true, ansonsten false</returns>
        bool? ShowDialog(string titel, object datacontext, double minHeigth = 0, double minWidth=0, double maxHeigth = double.PositiveInfinity, double maxWidth = double.PositiveInfinity);
        /// <summary>
        /// Zeigt ein Dialog an
        /// </summary>
        /// <param name="titel">Titel für den Dialog<</param>
        /// <param name="datacontext">DataContext für den Dialog</param>
        /// <param name="settings">ApplicationsSetting für Height and Width</param>
        /// <param name="pathHeigthSetting">Name für Height Setting</param>
        /// <param name="pathWidthSetting">Name für Width Setting</param>
        /// <param name="minHeigth">Minimum Height</param>
        /// <param name="minWidth">Minimum Width</param>
        /// <param name="maxHeigth">Maximum Height</param>
        /// <param name="maxWidth">Maximum Width</param>
        /// <returns>true wenn DialogResult=true, ansonsten false</returns>
        bool? ShowDialog(string titel, object datacontext, ApplicationSettingsBase settings, string pathHeigthSetting, string pathWidthSetting, double minHeigth = 0, double minWidth = 0, double maxHeigth = double.PositiveInfinity, double maxWidth = double.PositiveInfinity);
    }
    ///<summary>
    /// Implementierung von <see cref="IUIDialogWindowService"/>
    ///</summary>
    [PartCreationPolicy(CreationPolicy.Shared)]
    [Export(typeof(IUIDialogWindowService))]
    public class WpfUIDialogWindowService : IUIDialogWindowService
    {
        #region Implementation of IUIDialogWindowService
        ///<summary>
        /// Zeigt ein Dialog an.
        ///</summary>
        ///<param name="titel">Titel für den Dialog</param>
        ///<param name="datacontext">DataContext für den Dialog</param>
        ///<returns>true wenn DialogResult=true, ansonsten false</returns>
        public bool? ShowDialog(string titel, object datacontext)
        {
            var win = new DialogWindow {Title = titel, DataContext = datacontext};
            return win.ShowDialog();
        }
        ///<summary>
        /// Zeigt ein Dialog an.
        ///</summary>
        ///<param name="titel">Titel für den Dialog</param>
        ///<param name="datacontext">DataContext für den Dialog</param>
        ///<param name="minHeigth">Minimum Height</param>
        ///<param name="minWidth">Minimum Width</param>
        ///<param name="maxHeigth">Maximum Height</param>
        ///<param name="maxWidth">Maximum Width</param>
        ///<returns>true wenn DialogResult=true, ansonsten false</returns>
        public bool? ShowDialog(string titel, object datacontext, double minHeigth = 0, double minWidth = 0, double maxHeigth = double.PositiveInfinity, double maxWidth = double.PositiveInfinity)
        {
            var win = new DialogWindow { Title = titel, DataContext = datacontext };
            win.MinHeight = minHeigth;
            win.MinWidth = minWidth;
            win.MaxHeight = maxHeigth;
            win.MaxWidth = maxWidth;
            return win.ShowDialog();
        }
        /// <summary>
        /// Zeigt ein Dialog an
        /// </summary>
        /// <param name="titel">Titel für den Dialog<</param>
        /// <param name="datacontext">DataContext für den Dialog</param>
        /// <param name="settings">ApplicationsSetting für Height and Width</param>
        /// <param name="pathHeigthSetting">Name für Height Setting</param>
        /// <param name="pathWidthSetting">Name für Width Setting</param>
        /// <param name="minHeigth">Minimum Height</param>
        /// <param name="minWidth">Minimum Width</param>
        /// <param name="maxHeigth">Maximum Height</param>
        /// <param name="maxWidth">Maximum Width</param>
        /// <returns>true wenn DialogResult=true, ansonsten false</returns>
        public bool? ShowDialog(string titel, object datacontext, ApplicationSettingsBase settings, string pathHeigthSetting, string pathWidthSetting, double minHeigth = 0, double minWidth = 0, double maxHeigth = double.PositiveInfinity, double maxWidth = double.PositiveInfinity)
        {
            var win = new DialogWindow { Title = titel, DataContext = datacontext };
            win.MinHeight = minHeigth;
            win.MinWidth = minWidth;
            win.MaxHeight = maxHeigth;
            win.MaxWidth = maxWidth;
            try
            {
                if(settings != null)
                {
                    win.SizeToContent = SizeToContent.Manual;
                    var height = settings[pathHeigthSetting];
                    var width = settings[pathWidthSetting];
                    BindingOperations.SetBinding(win, FrameworkElement.HeightProperty, new Binding(pathHeigthSetting) { Source = settings, Mode = BindingMode.TwoWay });
                    BindingOperations.SetBinding(win, FrameworkElement.WidthProperty, new Binding(pathWidthSetting) { Source = settings, Mode = BindingMode.TwoWay });
                    win.Height = (double)height;
                    win.Width = (double)width;
                }
            }
            catch
            {
                win.SizeToContent = SizeToContent.WidthAndHeight;
            }
            return win.ShowDialog();
        }
       
       
        #endregion
    }

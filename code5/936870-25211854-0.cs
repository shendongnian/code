    public class MyWindow : RadWindow
    {
        #region Public Methods
        /// <summary>
        /// Alerts the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="width">The width.</param>
        public static void Alert(string message, int width = 400 )
        {
            var dialogParams = new DialogParameters
            {
                Content = new TextBlock()
                {
                    Text = message,
                    Width = width,
                    TextWrapping = TextWrapping.Wrap
                },            
                Owner = Application.Current.MainWindow
            };
            RadWindow.Alert(dialogParams);
        }
        /// <summary>
        /// Confirms the specified content.
        /// </summary>
        /// <param name="message">The content.</param>
        /// <param name="closed">The closed.</param>
        /// <param name="width">The width.</param>
        public static void Confirm(string message, EventHandler<WindowClosedEventArgs> closed, int width = 400)
        {
            RadWindow.Confirm(new DialogParameters
            {
                Content = new TextBlock()
                {                   
                    Text = message,
                    Width = width,                   
                    TextWrapping = TextWrapping.Wrap
                },
                Closed = closed,                  
                Owner = Application.Current.MainWindow
            });
        }
        #endregion Public Methods
    }

    /// <summary>
    /// Class that holds the settings for message box dialogs.
    /// </summary>
    public class MessageBoxSettings
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public MessageBoxSettings()
        {
            this.AffirmativeButtonText = "OK";
            this.NegativeButtonText = "Cancel";
            this.MessageDialogStyle = MessageDialogStyle.AffirmativeAndNegative;
            this.MetroColorDialogScheme = MetroDialogColorScheme.Theme;
            this.Animation = false;
        }
        /// <summary>
        /// Sets the button styles to use.
        /// Default is 'OK' and 'Cancel'.
        /// </summary>
        public MessageDialogStyle MessageDialogStyle { get; set; }
        /// <summary>
        /// The color sheme to use for the dialog.
        /// </summary>
        public MetroDialogColorScheme MetroColorDialogScheme { get; set; }
        /// <summary>
        /// Affirmative button text. Default OK.
        /// </summary>
        public string AffirmativeButtonText { get; set; }
        /// <summary>
        /// The negative button text to use.
        /// </summary>
        public string NegativeButtonText { get; set; }
        /// <summary>
        /// First auxillary button text.
        /// </summary>
        public string FirstAuxillaryButtonText { get; set; }
        /// <summary>
        /// Second auxillary button text.
        /// </summary>
        public string SecondAuxiliaryButtonText { get; set; }
        /// <summary>
        /// Show animation on the dialog.
        /// </summary>
        public bool Animation { get; set; }
    }

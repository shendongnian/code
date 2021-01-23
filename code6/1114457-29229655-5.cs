    /// <summary>
    /// View model for the message box view.
    /// </summary>
    public class MessageBoxViewModel : DialogViewModel<MessageDialogResult>
    {
        private MessageBoxSettings settings;
        #region Initialisation.
        /// <summary>
        /// Null.
        /// </summary>
        public MessageBoxViewModel() { }
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="title">The title of the message box dialog.</param>
        /// <param name="message">The message to display in the message box.</param>
        public MessageBoxViewModel(string title, string message)
        {
            this.Title = title;
            this.DialogBody = message;
            if (this.settings == null)
                this.settings = new MessageBoxSettings();
            SetDialogVisuals();
        }
        /// <summary>
        /// Overloaded.
        /// </summary>
        /// <param name="title">The title of the message box dialog.</param>
        /// <param name="message">The message to display in the message box.</param>
        /// <param name="settings">MessageBoxSettings for the dialog.</param>
        public MessageBoxViewModel(string title, string message, MessageBoxSettings settings)
        {
            this.Title = title;
            this.DialogBody = message;
            this.settings = settings;
            SetDialogVisuals();
        }
        #endregion // Initialisation.
        #region Class Methods.
        /// <summary>
        /// Set the dialog visuals based on the MessageBoxSettings.
        /// </summary>
        private void SetDialogVisuals()
        {
            // Set dialog button visibility.
            switch (settings.MessageDialogStyle)
            {
                case MessageDialogStyle.Affirmative:
                    this.AffirmativeButtonVisibility = Visibility.Visible;
                    this.NegativeButtonVisibility = Visibility.Collapsed;
                    this.FirstAuxillaryButtonVisibility = Visibility.Collapsed;
                    this.SecondAuxillaryButtonVisibility = Visibility.Collapsed;
                    break;
                case MessageDialogStyle.AffirmativeAndNegative:
                    this.AffirmativeButtonVisibility = Visibility.Visible;
                    this.NegativeButtonVisibility = Visibility.Visible;
                    this.FirstAuxillaryButtonVisibility = Visibility.Collapsed;
                    this.SecondAuxillaryButtonVisibility = Visibility.Collapsed;
                    break;
                case MessageDialogStyle.AffirmativeAndNegativeAndDoubleAuxiliary:
                    this.AffirmativeButtonVisibility = Visibility.Visible;
                    this.NegativeButtonVisibility = Visibility.Visible;
                    this.FirstAuxillaryButtonVisibility = Visibility.Visible;
                    this.SecondAuxillaryButtonVisibility = Visibility.Visible;
                    break;
                case MessageDialogStyle.AffirmativeAndNegativeAndSingleAuxiliary:
                    this.AffirmativeButtonVisibility = Visibility.Visible;
                    this.NegativeButtonVisibility = Visibility.Visible;
                    this.FirstAuxillaryButtonVisibility = Visibility.Visible;
                    this.SecondAuxillaryButtonVisibility = Visibility.Collapsed;
                    break;
                default:
                    break;
            }
            // Set the button text.
            this.AffirmativeButtonText = settings.AffirmativeButtonText;
            this.NegativeButtonText = settings.NegativeButtonText;
            this.FirstAuxillaryButtonText = settings.FirstAuxillaryButtonText;
            this.SecondAuxiliaryButtonText = settings.SecondAuxiliaryButtonText;
            // Color scheme.
            string name = MahApps.Metro.ThemeManager.DetectAppStyle(Application.Current).Item2.Name;
            this.Background = settings.MetroColorDialogScheme == MetroDialogColorScheme.Theme ?
                MahApps.Metro.ThemeManager.Accents
                    .Where(a => a.Name.CompareNoCase(name))
                    .First().Resources["HighlightBrush"] as SolidColorBrush :
                new SolidColorBrush(System.Windows.Media.Colors.White);
        }
        /// <summary>
        /// Handles the button click events for the affermative button.
        /// </summary>
        public void AffirmativeButtonClick()
        {
            Close(MessageDialogResult.Affirmative);
        }
        /// <summary>
        /// Handles the button click events for the negative button.
        /// </summary>
        public void NegativeButtonClick()
        {
            Close(MessageDialogResult.Negative);
        }
        /// <summary>
        /// Handles the button click events for the first auxillary button.
        /// </summary>
        public void FirstAuxillaryButtonClick()
        {
            Close(MessageDialogResult.FirstAuxiliary);
        }
        /// <summary>
        /// Handles the button click events for the second auxillary button.
        /// </summary>
        public void SecondAuxillaryButtonClick()
        {
            Close(MessageDialogResult.SecondAuxiliary);
        }
        #endregion // Class Methods.
        #region Properties.
        /// <summary>
        /// Hold the dialog title.
        /// </summary>
        private string title;
        public string Title
        {
            get { return title; }
            set
            {
                if (title == value)
                    return;
                title = value;
                NotifyOfPropertyChange(() => Title);
            }
        }
        /// <summary>
        /// Hold the text for the dialog body.
        /// </summary>
        private string dialogBody;
        public string DialogBody
        {
            get { return dialogBody; }
            set
            {
                if (dialogBody == value)
                    return;
                dialogBody = value;
                NotifyOfPropertyChange(() => DialogBody);
            }
        }
        /// <summary>
        /// Sets the button styles to use.
        /// Default is 'OK' and 'Cancel'.
        /// </summary>
        private MessageDialogStyle messageDialogStyle =
            MessageDialogStyle.AffirmativeAndNegative;
        public MessageDialogStyle MessageDialogStyle
        {
            get { return messageDialogStyle; }
            set
            {
                if (messageDialogStyle == value)
                    return;
                messageDialogStyle = value;
                NotifyOfPropertyChange(() => MessageDialogStyle);
            }
        }
        /// <summary>
        /// The color sheme to use for the dialog.
        /// </summary>
        private SolidColorBrush background;
        public SolidColorBrush Background
        {
            get { return background; }
            set
            {
                if (background == value)
                    return;
                background = value;
                NotifyOfPropertyChange(() => Background);
            }
        }
        /// <summary>
        /// Affirmative button text. Default OK.
        /// </summary>
        private string affirmativeButtonText = "OK";
        public string AffirmativeButtonText
        {
            get { return affirmativeButtonText; }
            set
            {
                if (affirmativeButtonText == value)
                    return;
                affirmativeButtonText = value;
                NotifyOfPropertyChange(() => AffirmativeButtonText);
            }
        }
        /// <summary>
        /// Visibility for the default affirmative button.
        /// </summary>
        private Visibility affirmativeButtonVisibility = Visibility.Visible;
        public Visibility AffirmativeButtonVisibility
        {
            get { return affirmativeButtonVisibility = Visibility.Visible; }
            set
            {
                if (affirmativeButtonVisibility == value)
                    return;
                affirmativeButtonVisibility = value;
                NotifyOfPropertyChange(() => AffirmativeButtonVisibility);
            }
        }
        /// <summary>
        /// The negative button text to use.
        /// </summary>
        private string negativeButtonText = "Cancel";
        public string NegativeButtonText
        {
            get { return negativeButtonText; }
            set
            {
                if (negativeButtonText == value)
                    return;
                negativeButtonText = value;
                NotifyOfPropertyChange(() => NegativeButtonText);
            }
        }
        /// <summary>
        /// Visibility for the default negative button.
        /// </summary>
        private Visibility negativeButtonVisibility = Visibility.Visible;
        public Visibility NegativeButtonVisibility
        {
            get { return negativeButtonVisibility; }
            set
            {
                if (negativeButtonVisibility == value)
                    return;
                negativeButtonVisibility = value;
                NotifyOfPropertyChange(() => NegativeButtonVisibility);
            }
        }
        /// <summary>
        /// First auxillary button text.
        /// </summary>
        private string firstAuxillaryButtonText;
        public string FirstAuxillaryButtonText
        {
            get { return firstAuxillaryButtonText; }
            set
            {
                if (firstAuxillaryButtonText == value)
                    return;
                firstAuxillaryButtonText = value;
                NotifyOfPropertyChange(() => FirstAuxillaryButtonText);
            }
        }
        /// <summary>
        /// First auxillary button visibility.
        /// </summary>
        private Visibility firstAuxillaryButtonVisibility = Visibility.Collapsed;
        public Visibility FirstAuxillaryButtonVisibility
        {
            get { return firstAuxillaryButtonVisibility; }
            set
            {
                if (firstAuxillaryButtonVisibility == value)
                    return;
                firstAuxillaryButtonVisibility = value;
                NotifyOfPropertyChange(() => FirstAuxillaryButtonVisibility);
            }
        }
        /// <summary>
        /// Second auxillary button text.
        /// </summary>
        private string secondAuxiliaryButtonText;
        public string SecondAuxiliaryButtonText
        {
            get { return secondAuxiliaryButtonText; }
            set
            {
                if (secondAuxiliaryButtonText == value)
                    return;
                secondAuxiliaryButtonText = value;
                NotifyOfPropertyChange(() => SecondAuxiliaryButtonText);
            }
        }
        /// <summary>
        /// Second auxillary button visibility.
        /// </summary>
        private Visibility secondAuxillaryButtonVisibility = Visibility.Collapsed;
        public Visibility SecondAuxillaryButtonVisibility
        {
            get { return secondAuxillaryButtonVisibility; }
            set
            {
                if (secondAuxillaryButtonVisibility == value)
                    return;
                secondAuxillaryButtonVisibility = value;
                NotifyOfPropertyChange(() => SecondAuxillaryButtonVisibility);
            }
        }
        #endregion // Properties.
    }

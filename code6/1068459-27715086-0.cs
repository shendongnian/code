    public partial class Prompt : UserControl
    {
        /// <summary>
        /// DependencyProperty for the OKCommand property.
        /// </summary>
        public static readonly DependencyProperty OKCommandProperty = DependencyProperty.Register("OKCommand", typeof(ICommand), typeof(Prompt));
        /// <summary>
        /// Gets or sets the command to invoke when the OKButton is pressed.
        /// </summary>
        public ICommand OKCommand
        {
            get { return (ICommand)GetValue(OKCommandProperty); }
            set { SetValue(OKCommandProperty, value); }
        }
        public Prompt()
        {
            InitializeComponent();
        }
    }

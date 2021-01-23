    public MainPage()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
            //Setup page transitions using custom class file
            //1. Turnstile transition
            Transitions.UseTurnstileTransition(this);
            //2. Slide transition
            //Transitions.UseSlideTransition(this);
            //3. Slide up/down transition
            //Transitions.UseSlideUpDownTransition(this);
            //4. Swivel transition
            //Transitions.UseSwivelTransition(this);
            //5. Rotate transition
            //Transitions.UseRotateTransition(this);
            //6. Roll transition
            //Transitions.UseRollTransition(this);
        }

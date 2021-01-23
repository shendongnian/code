        public MainMenuPage()
        {
            InitializeComponent();
            BaseTemplateHelper = new GPBaseTemplateHelper();
            if (BaseTemplateHelper != null)
            {
                this.DataContext = BaseTemplateHelper;
            }
        }

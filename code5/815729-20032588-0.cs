    public SecondForm: Principal
    {
        public Form PrincipalForm { get; set; }
        public SecondForm(Principal principalForm)
        {
            InitializeComponent();
            PrincipalForm = principalForm;
        }
        //  other stuff
    }

    public partial class Edit : XtraForm
    {
        public Patient Patient;
    
        public Edit() //empty constructor if you want to pass data manually via property
        {
            InitializeComponent();
        }
        public Edit(Patient patient)
        {
            InitializeComponent();
            Patient = patient;
        }
        //full code here
    }

    public partial class SampleFormIntermediate : BaseForm<SamplePresenter>
    {
        public SampleFormIntermediate()
        {
            InitializeComponent();
            Presenter = new SamplePresenter();
        }
    }

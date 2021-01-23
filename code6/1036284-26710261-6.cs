    public partial class View : Page, IPresentationModel
    {
        private Presenter _presenter;
        protected override void OnInitComplete(EventArgs e)
        {
            base.OnInitComplete(e);
            _presenter = new Presenter(this);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData(this, e);
            }
        }
        public string AProperty
        {
            set
            {
                aSpan.InnerHtml = value;
            }
        }
        public string ATextbox
        {
            get
            {
                return aTextbox.Value;
            }
            set
            {
                aTextbox.Value = value;
            }
        }
        public event EventHandler SaveData;
        public event EventHandler LoadData;
        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            SaveData(this, e);
            LoadData(this, e);
        }
    }

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
            LoadData(this, e);
        }
        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            SaveData(this, e);
        }
        public string AProperty
        {
            get
            {
                return aSpan.InnerHtml;
            }
            set
            {
                aSpan.InnerHtml = value;
            }
        }
        public event EventHandler SaveData;
        public event EventHandler LoadData;
    }

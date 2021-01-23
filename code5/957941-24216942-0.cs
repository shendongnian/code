        protected string HiddenFieldValue { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                HiddenFieldValue = x.ToString();
            else
                HiddenFieldValue = x.ToString();
        }

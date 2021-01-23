    public int TimeCount = 1;
        protected int Counter
        {
            get
            {
                if (ViewState["count"] == null)
                    return 0;
                int temp;
                return int.TryParse(ViewState["count"].ToString(), out temp) ? temp : 0;
            }
            set { ViewState["count"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["count"] = TimeCount.ToString();
            }
        }
        protected void Timer1_Tick(object sender, EventArgs e)
        {
            Counter++;
            Label1.Text = Counter.ToString();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Timer1.Enabled = true;
        }

        protected String TextButton1
        {
            get { return (String) ViewState["TextButton1"]; }
            set { ViewState["TextButton1"] = value; }
        }
        protected String TextButton2
        {
            get { return (String)ViewState["TextButton2"]; }
            set { ViewState["TextButton2"] = value; }
        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            CreateControls();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                UpdatePage();
            }
        }
        protected void CreateControls()
        {
            Button button1 = new Button();
            button1.ID = "_Button1";
            button1.Text = String.IsNullOrEmpty(TextButton1) ? "The First Value" : TextButton1; 
            button1.Click += new System.EventHandler(_ClickEvent1);
            _Panel.Controls.Add(button1);
            Button button2 = new Button();
            button2.ID = "_Button2";
            button2.Text = String.IsNullOrEmpty(TextButton2) ? "The First Value" : TextButton2; 
            button2.Click += new System.EventHandler(_ClickEvent2);
            _Panel.Controls.Add(button2);
        }
        protected void UpdatePage()
        {
            Button button1 = ((Button)_Panel.FindControl("_Button1"));
            button1.Text = String.IsNullOrEmpty(TextButton1) ? "The First Value" : TextButton1; 
            Button button2 = ((Button)_Panel.FindControl("_Button2"));
            button2.Text = String.IsNullOrEmpty(TextButton2) ? "The First Value" : TextButton2; 
        }
        protected void _ClickEvent1(object sender, EventArgs e)
        {
            TextButton1 = "test";
            Button b = (Button) sender ;
            b.Text = TextButton1;
        }
        protected void _ClickEvent2(object sender, EventArgs e)
        {
            TextButton2 = "test";
            Button b = (Button)sender;
            b.Text = TextButton2;
        }

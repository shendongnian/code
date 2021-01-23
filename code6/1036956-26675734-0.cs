    protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                for (int i = 0; i < 5; i++)
                {
                    RadioButton r = new RadioButton();
                    r.Text = i.ToString();
                    r.ID = i.ToString();
                    r.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                    Panel1.Controls.Add(r);
                }
            }
        }

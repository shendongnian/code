     public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["Counter"] = 0;
            }
            else
            {
                //Sync ViewState Info to maintain the state
                List<string> texts = new List<string>();
    
                //The dynamic textbox values are captured from Request.Form
                foreach (string key in Request.Form.Keys)
                {
                    if (key.Contains("ctrlsuper"))
                    {
                        texts.Add(Request.Form[key]);
                    }
                }
                Texts = texts;
            }
        }
    
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            //Rerender the textboxes to UI and add one more new empty textbox.
            for (int i = 0; i <= Convert.ToInt32(ViewState["Counter"]); i++)
            {
                HtmlGenericControl div = new HtmlGenericControl("div");
                TextBox tb = new TextBox();
                tb.ID = "ctrlsuper" + i.ToString();
    
                //Refresh the textbox text according to its previous value.
                if (Texts.Count > 0 && i < Texts.Count)
                {
                    tb.Text = Texts[i];
                }
    
                div.Controls.Add(tb);
                pnlControls.Controls.Add(div);
            }
    
            ViewState["Counter"] = Convert.ToInt32(ViewState["Counter"]) + 1;
        }
    
        public List<string> Texts
        {
            get
            {
                if (ViewState["Texts"] == null)
                {
                    return new List<string>();
                }
                else
                {
                    return ViewState["Texts"] as List<string>;
                }
            }
            set
            {
                ViewState["Texts"] = value;
            }
        }
    }

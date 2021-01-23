     protected void Page_Load(object sender, EventArgs e)
        {
            if (ViewState["val"] != null)
            {
                int s = Convert.ToInt32(ViewState["val"]);
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (ViewState["val"] != null)
            {
                int s = Convert.ToInt32(ViewState["val"]);
                s = s + 5;
                ViewState["val"] = s;
            }
            else
            {
                ViewState["val"] = 6;
            }
        }

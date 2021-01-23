    //chksOne is checkboxlist in the markup.
    public List<string> Values = new List<string>() { "CHK 1", "CHK 2", "CHK 3", "CHK 4" };
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
            return;
        chksOne.DataSource = Values;
        chksOne.DataBind();
        
        if (Request.Cookies.AllKeys.Contains("CBL"))
        {
            string value = Request.Cookies["CBL"].Value;
            if (value == null)
                return;
            string[] vals = value.Split('|');
            for (int i = 0, ii = chksOne.Items.Count; i < ii; i++)
                if (vals.Contains(chksOne.Items[i].Value))
                    chksOne.Items[i].Selected = true;
        }
    }
    protected void chksOne_SelectedIndexChanged(object sender, EventArgs e)
    {
        CheckBoxList list = sender as CheckBoxList;
        if(list == null)
            return;
        List<string> tmpValues = new List<string>();
        for (int i = 0, ii = list.Items.Count; i < ii; i++)
        {
            if (list.Items[i].Selected)
                tmpValues.Add(list.Items[i].Value);
        }
        Response.Cookies.Add(new HttpCookie("CBL", string.Join("|", tmpValues.ToArray())));
        Response.Cookies["CBL"].Expires = DateTime.Now.AddDays(30);
    }

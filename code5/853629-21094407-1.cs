    int i 
    {
        get
        {
           if(Session["ClickCount"] == null)
           {
              Session["ClickCount"] = 0;
           }
           return int.Parse(Session["ClickCount"].ToString());
        }
        set
        {
           Session["ClickCount"] = value;
        }
    }    
    protected void Page_Load(object sender, EventArgs e)
    {
        number_lbl.Text = i + "";
    }
    
    protected void check_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt16(textbox.Text) == i)
            right_wrong_lbl.Text = "right";
        else
            right_wrong_lbl.Text = "wrong";
        check.Enabled = false;
        next.Visible = true;
    }
    
    protected void next_Click(object sender, EventArgs e)
    {
        i++;
        check.Enabled = true;
        next.Visible = false;
        number_lbl.Text = i + "";
        textbox.Text = "";
    }

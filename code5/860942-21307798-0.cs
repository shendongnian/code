    protected void Page_Load(object sender, EventArgs e)
    {
            DataBind();           
    }
    public string GetGuiLocalString(string id)
    {
            string s = "hello";
            Label lbl = (Label)Form.FindControl(id);
            if(lbl!=null)
            {
                if ( ! string.IsNullOrEmpty(lbl.Text))
                    s = lbl.Text;
            }            
            return s;
    }

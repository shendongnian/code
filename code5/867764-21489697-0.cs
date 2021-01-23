    this is how its should be imo:
    protected void Button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= Convert.ToInt32(ViewState["Counter"]); i++)
            {
                HtmlGenericControl div = new HtmlGenericControl("div");
                RadioButton rb = new RadioButton();
                rb.ID = i.ToString();
                rb.Text = "Button" + i.ToString();
                rb.GroupName = "RB";
                rb.CheckedChanged += +=new EventHandler(radioButton_CheckedChanged);
    
                div.Controls.Add(rb);
                Panel1.Controls.Add(div);
            }
    
            ViewState["Counter"] = Convert.ToInt32(ViewState["Counter"]) + 1;
        }
        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton btn = sender as RadioButton;
            TextBox1.Text = btn.Text;
        }

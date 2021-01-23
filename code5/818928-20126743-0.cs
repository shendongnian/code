    protected void ExecuteCode_Click(object sender, EventArgs e)
    {    
        List<string> tbids = new List<string>();
        int amount = Convert.ToInt32(DropDownListIP.SelectedValue);
            for (int num = 1; num <= amount; num++)
            {
                HtmlGenericControl div = new HtmlGenericControl("div");
                TextBox t = new TextBox();
                t.ID = "textBoxName" + num.ToString();
                div.Controls.Add(t);
                phDynamicTextBox.Controls.Add(div);
                tbids.Add(t.ID);
            }
            Session["tbids"] = tbids;
            ButtonRequest.Visible = true;
    }
    protected void ButtonRequest_Click(object sender, EventArgs e)
        {
            string str = "";
            var tbids = (List<string>)Session["tbids"];
            foreach (var id in tbids)
            {
                try
                {
                    str += Request[id]+" "; //here get value tb with id;
                }
                catch
                {
                }
            }
            TextBoxFinal.Text = str;
        }

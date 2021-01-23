    protected void Page_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 26; i++)
            {
                Button btn = new Button();
                btn.ID = "btn" + i.ToString();
                btn.Text = ((char)('A' + i)).ToString();
                btn.CommandArgument = ((char)('A' + i)).ToString();
                btn.Click += btn_Click;
                dv.Controls.Add(btn);
            }
        }
        private void btn_Click(object sender, object arg)
        {
            Div1.InnerHtml += "\nClicked : " + ((Button)sender).ID;
            Div1.InnerHtml += "<br/>arg : " + ((Button)sender).CommandArgument;
        }

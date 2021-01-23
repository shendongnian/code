        protected void Page_Load(object sender, EventArgs e)
        {
            DeepControlSearch(Page);
        }
        private void DeepControlSearch(Control control)
        {
            if (control.HasControls())
            {
                for (int c = control.Controls.Count - 1; c > -1; c--)
                {
                    DeepControlSearch(control.Controls[c]);
                }
            }
            if (control is TextBox)
            {
                WrapTextBox((TextBox)control);
            }
        }
        private void WrapTextBox(TextBox textBox)
        {
            System.Web.UI.HtmlControls.HtmlGenericControl div = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
            div.ID = String.Format("div{0}", textBox.ID.Replace("txt", String.Empty));
            div.Attributes["runat"] = "server";
            Control parent = textBox.Parent;
            parent.Controls.Remove(textBox);
            div.Controls.Add(textBox);
            parent.Controls.Add(div);
        }

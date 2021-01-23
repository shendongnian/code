        public void ShowAllPostBackData()
        {
            if (IsPostBack)
            {
                string[] keys = Request.Form.AllKeys;
                Literal ctlAllPostbackData = new Literal();
                ctlAllPostbackData.Text = "<div class='well well-lg' style='border:1px solid black;z-index:99999;position:absolute;'><h3>All postback data:</h3><br />";
                for (int i = 0; i < keys.Length; i++)
                {
                    ctlAllPostbackData.Text += "<b>" + keys[i] + "</b>: " + Request[keys[i]] + "<br />";
                }
                ctlAllPostbackData.Text += "</div>";
                this.Controls.Add(ctlAllPostbackData);
            }
        }

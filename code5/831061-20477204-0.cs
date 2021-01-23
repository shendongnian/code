        protected void Page_Load(object sender, EventArgs e)
        {
            for (int T = 0; T <= 26; T++)
            {
                Label x = new Label();
                x.ID = T.ToString();
                x.Text = "orem ipsum dolor sit amet, consectetur adipiscing elit. Nulla blandit id felis ac volutpat. Aenean tempor faucibus est, ac feugiat libero egestas sit amet. Aliquam";
                Label y = new Label();
                y.ID = "Title_" + T.ToString();
                y.Text = "Title " + T.ToString();
                RadioButton Radio1 = new RadioButton();
                Radio1.ID = "R_" + T.ToString();
                Radio1.Text = "Yes";
                Radio1.GroupName = "Radio_" + T.ToString();
                Radio1.CheckedChanged += new EventHandler(this.CheckedChanged);
                Radio1.AutoPostBack = true;
                RadioButton Radio2 = new RadioButton();
                Radio2.ID = "RX_" + T.ToString();
                Radio2.Text = "No";
                Radio2.GroupName = "Radio_" + T.ToString();
                Radio2.CheckedChanged += new EventHandler(this.CheckedChanged);
                Radio2.AutoPostBack = true;
                Panel StatusBar = new Panel();
                StatusBar.ID = "status_" + T.ToString();
                PlaceHolder pcl = new PlaceHolder();
                pcl.ID = "test_" + T.ToString();
                pcl.Controls.Add(y);
                pcl.Controls.Add(new LiteralControl("<br>"));
                pcl.Controls.Add(x);
                pcl.Controls.Add(new LiteralControl("<br>"));
                pcl.Controls.Add(Radio1);
                pcl.Controls.Add(Radio2);
                pcl.Controls.Add(new LiteralControl("<br><br>"));
                form1.Controls.Add(pcl);
                form1.Controls.Add(StatusBar);
            }
            //form1.Controls.Add(new PlaceHolder { ID = "MyStatusBar" });
        }
        protected void CheckedChanged(object sender, EventArgs e)
        {
            RadioButton tRadio = (RadioButton)sender;
            var T = tRadio.ID.Split('_')[1];
            var statusBarID = "status_" + T;
            var StatusBar = tRadio.Parent.FindControl(statusBarID) as Panel;
            if (tRadio.Text == "Yes")
            {
                StatusBar.Controls.Add(new LiteralControl("SampleText"));
            }
        }

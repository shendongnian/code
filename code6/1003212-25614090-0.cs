    protected void Page_Load(object sender, EventArgs e)
        {
            string[] arrProcess = new[] { "link 1", "link 2", "link 3" };
            int listItemIds = 1;
            // List<CompanyModel1> companies1 = new List<CompanyModel1>();
            for (int ar = 0; ar < arrProcess.Length; ar++)
            {
                HyperLink lnk = new HyperLink();
                lnk.ID = "lnk" + listItemIds;
                lnk.ClientIDMode = ClientIDMode.Static;
                lnk.NavigateUrl = "#";
                lnk.Text = arrProcess[ar];
                lnk.Attributes.Add("onClick", "changeControlStyle('" + lnk.ClientID + "');"); //This is to prevent the page to reload
                listItemIds++;
                PlaceHolder1.Controls.Add(lnk); // Adding the LinkButton in PlaceHolder
                //PlaceHolder1.Controls.Add(new LiteralControl("<br />"));
            }
        }

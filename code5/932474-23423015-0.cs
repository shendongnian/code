    public void ButtonOk_Click(object sender, EventArgs e)
        {
            // First part: Saves info on first page.
            if (Session["Gig"] == null)
            {
                Session.Add("Gig", new List<string>());
            }
            List<string> list = (List<string>)Session["Gig"];
            list.Add("new Data");
            Session["Gig"] = list;
            Server.Transfer("~/GigManagerWebForm.aspx");
        }
    // On the GigManagerWebForm.aspx
    private void Page_Load(object sender, EventArgs e)
        {
            AddGig();
        }
    public void AddGig()
        {
            if(Session["Gig"] != null)
            {
                //Reads info into variables on the second page.
                List<string> getData = (List<string>)(Session["Gig"]);
                ListBox1.Items.AddRange(getData.Select(d => new ListItem(d)).ToArray());
                Session["Gig"] = getData;
            }
        }

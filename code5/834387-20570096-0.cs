    protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                HttpCookie testCokkie = new HttpCookie("ExampleCookie");
                testCokkie.Expires = DateTime.Now.AddDays(5);
                Response.Cookies.Add(testCokkie);
    
            }
        }
     protected void btnTest_Click(object sender, EventArgs e)
        {
            HttpCookie ExampleCookie = Request.Cookies["ExampleCookie"];
            int tempIndex = 0;
            foreach (ListViewItem item in catListView.Items)
            {
                Label catLabel = (Label)item.FindControl("lblcat");
                ExampleCookie["cat" + tempIndex.ToString()] = catLabel.Text.ToString();
                tempIndex = tempIndex + 1;
            }
        }

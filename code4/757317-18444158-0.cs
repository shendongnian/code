    protected void Page_Load(object sender, EventArgs e) {
    {
       if(!IsPostBack)
        {
        if (Session["beachBach"] != null)
        {
            numberOfBeachBookingInteger += 1;
           beachBachLabel.Text = numberOfBeachBookingInteger.ToString();
        }
      }

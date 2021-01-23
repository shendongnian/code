    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        { 
         }
         BindCommentData(); // New method which binds data.
    }
    Private void BindCommentData()
    {
        // Here you get the dt..
        if(dt.Rows.Count != 0)
        {
          ltrlFirst.Text = dt.Rows[i][2].ToString();
          ltrlSecond.Text = dt.Rows[i][0].ToString();
          ltrlThird.Text = Convert.ToDateTime(dt.Rows[i][1]).ToLongTimeString();
        }
    }

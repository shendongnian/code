        **100% Good Solution**
        **Using this code** 
        (1) Calendar will not show at Page Load
        (2) Calendar will show when you will Click SelectDate(btnSelectDate) Button
        (3) Calendar Will disappear after date selection
        (4) Calendar will not disappear on next month selection        
        protected void Page_Load(object sender, EventArgs e)
        {
          if (!Page.IsPostBack)
          {
            Calendar1.Visible = false;
          }
        }
        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            Calendar1.Visible = false;
        }
        protected void btnSelectDate_Click(object sender, EventArgs e)
        {
          Calendar1.Visible = true;
        }

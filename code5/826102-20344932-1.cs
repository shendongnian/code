     protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }
        public void BindData()
        {
            ArrayList myList = new ArrayList();
            myList.Add(new Post() { Author = "Abide", Title = "The Post", Date = DateTime.Now, IPAddress = "192.168.0.9", Message = "It works", MessageID = "5" });
            gvPosts.DataSource = myList;
            gvPosts.DataBind();
        }
        protected void gvPosts_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow gvr = (GridViewRow)gvPosts.Rows[e.RowIndex];
            int MessageID = Convert.ToInt32(gvPosts.DataKeys[e.RowIndex].Value.ToString());
            TextBox Title = (TextBox)gvr.FindControl("tbGridTitle");
            TextBox Message = (TextBox)gvr.FindControl("tbGridMessage");
            TextBox Author = (TextBox)gvr.FindControl("tbGridAuthor");
         // do your stuff here
          
        }
        protected void gvPosts_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvPosts.EditIndex = e.NewEditIndex;
            BindData();
            
        }
        protected void gvPosts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
        }
        protected void gvPosts_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvPosts.EditIndex = -1;
            BindData();
        }
    }

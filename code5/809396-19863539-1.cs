     protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
              loadList();
              BindGrid();
            }
        }
 
    Public static void BindGrid()
       { 
       // Code to Bind Gridview.
       }

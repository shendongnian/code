    protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    var boundColumn = new BoundField();
                    boundColumn.DataField = "LastName";
                    boundColumn.HeaderText = "Last Name";
                    boundColumn.SortExpression = "LastName";
                    GVPictures.Columns.Add(boundColumn);                
                    BindGridView();
                }
            }

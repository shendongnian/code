    protected void OnInitComplete( EventArgs e )
    {
        if( !Page.IsPostBack )
        {
            CreateMyControls();
        }
    }

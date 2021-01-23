    PageLoad()
    {
       if(!Page.IsPostBack)
       { 
         PopulateMyGrid();
       }
    }
      
    private void PopulateMyGrid()
    {
        DataTable myDataTable=null;
        // Your DAL code goes here (you can fill the datatable from your database)
        myGrid.DataSource = myDatatable;
        myGrid.DataBind();
    }

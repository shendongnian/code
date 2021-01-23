    var myDataTable = new DataTable();
    if (!IsPostBack)
    {
        Session["myDataTable"] = null;
        //clear the session on a fresh page view and probably you 
        //want code here to go get the data from the database, ie:
        myDataTable = GetDataFromDatabase();
    }
    else
    {
        if (Session["myDataTable"] != null)
        {
            myDataTable = (DataTable)Session["myDataTable"];
        }
        else
        {
            myDataTable = GetDataFromDatabase();
        }
    }
    private DataTable GetDataFromDatabase()
    {
        //returns DataTable populated from Database
    } 

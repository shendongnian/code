    if (cell.HasControls())
    {
        //get reference to the button column
        btnSort = cell.Controls[0] as LinkButton;
        image = new System.Web.UI.WebControls.Image();
        if (ViewState["sortExp"] != null && btnSort != null)
        {
            ....
        }
    }

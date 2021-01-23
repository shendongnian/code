    protected void Grid_RowDataBound(Object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
       
       if(e.Row.RowType == DataControlRowType.Footer)
       { 
             e.Row.cells[2].children[0].innerText = ClsSum;
             e.Row.cells[3].children[0].innerText = NonSaleSum;
             e.Row.cells[7].children[0].innerText = SecSum;
        }
    }

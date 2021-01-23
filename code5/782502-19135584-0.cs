    List<Dispatch> objDispatch = (List<Dispatch>)Session["Data"];
    List<Dispatch> filteredDispatches = objDispatch.Where(dispatch => dispatch.InvoiceDate.Date >= Convert.ToDateTime(FromDate).Date && dispatch.InvoiceDate.Date <= Convert.ToDateTime(ToDate).Date).ToList();
    if (ddlTransporterName.SelectedItem.Text != "ALL")
    {
        filteredDispatches = filteredDispatches.Where(dispatch => dispatch.CustomerTransName == ddlTransporterName.SelectedItem.Text).ToList();
    }

    List<Dispatch> objDispatch = (List<Dispatch>)Session["Data"];
    var _fromDate = Convert.ToDateTime(FromDate);
    var _toDate = Convert.ToDateTime(ToDate);
    objDispatch = objDispatch
        .FindAll(dispatch => Selector(
             dispatch, ddlTransporterName.SelectedItem.Text, _fromDate, _toDate));
    static bool Selector(
        Dispatch dispatch, string name, DateTime fromDate, DateTime toDate)
    {
        if (dispatch.CustomerTransName == "ALL")
        {
            return dispatch.InvoiceDate.Date >= fromDate.Date
                && dispatch.InvoiceDate.Date <= toDate.Date;
        }
        return dispatch.CustomerTransName == name;
    }

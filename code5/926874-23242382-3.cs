    protected void gv_RowDataBound(object sender, GridViewRowEventArgs e) {
        if ((e.Row.RowType == DataControlRowType.DataRow)) {
            string QueryString = DataBinder.Eval(e.Row.DataItem, "QueryString").ToString;
            string NavigateURL = ResolveUrl(("~/URL.aspx?QueryString=" + QueryString));
            e.Row.Attributes.Add("onClick", string.Format("javascript:window.location=\'{0}\';", NavigateURL));
            e.Row.Style.Add("cursor", "pointer");
        }
    }

    Save your sort order in view state
    if (ViewState["sortOrder"] != null)
                {
                    ViewState["sortExpression"] = e.SortExpression;
                    if (ViewState["sortOrder"].ToString().ToUpper() == "ASCENDING")
                    {
                        e.SortDirection = SortDirection.Descending;
                        ViewState["sortOrder"] = SortDirection.Descending.ToString();
                    }
                    else
                    {
                        e.SortDirection = SortDirection.Ascending;
                        ViewState["sortOrder"] = SortDirection.Ascending.ToString();
                    }
                }
                else
                {
                    ViewState["sortExpression"] = e.SortExpression;
                    ViewState["sortOrder"] = e.SortDirection.ToString();
                }

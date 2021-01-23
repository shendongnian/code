                if (!Page.IsPostBack)
            {
                ViewState["data"] = MyDataset;
                DataListView.DataSource = ViewState["data"];
                DataListView.DataBind();
            }
            if (Page.IsPostBack)
            {
                DataListView.DataSource = ViewState["data"];
                DataListView.DataBind();
            }

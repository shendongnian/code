     void Page_PreRender(object sender, EventArgs e)
        {
            DataSet dataSet = Data.fetchDataSet();
            GridView DyGV_Element = new GridView();
            DyGV_Element.AutoGenerateColumns = false;
            DyGV_Element.DataSource = dataSet.Tables[0].DefaultView;
            DyGV_Element.DataBind();
            GridView DyGV_SubGroup = new GridView();
            DyGV_SubGroup.DataSource = dataSet.Tables[1].DefaultView;
            DyGV_SubGroup.DataBind();
            GridView DyGV_Comments = new GridView();
            DyGV_Comments.AutoGenerateColumns = false;
            DyGV_Comments.DataSource = dataSet.Tables[2].DefaultView;
            DyGV_Comments.DataBind();
            Panel1.Controls.Add(DyGV_Element);
            Panel1.Controls.Add(DyGV_SubGroup);
            Panel1.Controls.Add(DyGV_Comments);
        }

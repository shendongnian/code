    for (int i = 1; i < numOfGroups + 1; i++)
    {
        GridView grd = new GridView();
        grd.ID = "GridView" + i.ToString();
        grd.BackColor = getColor(i);
        grd.Attributes.Add("class", "float-left"); //here
        grd.DataSource = dt; // some data source
        grd.DataBind();
        pnlResult.Controls.Add(grd);
    }

    ddlListMine.DataSource = GetSomeChickens();
    ddListMine.DataTextField = "ChickenName";
    ddListMine.DataValueField= "NumberOfEggsChickenLay";
    ddListMine.DataBind();
    ddlListMine.Items.Add(0, new ListItem("Select Category", String.Empty));
    ddListMine.SelectedIndex = 0;

            cblTest.DataSource = "YourDataTableOrDataset";
            cblTest.DataValueField = "YourIDColumnFromYourTable";
            cblTest.DataTextField = "YourColumnName";
            cblTest.RepeatDirection = RepeatDirection.Horizontal;//Option of vertical
            cblTest.RepeatColumns = 5; //or however many you need i.e how many columns you want to go across before repeating
            cblTest.CssClass = "YourCSSClass"; //for styling the checkboxlist
            cblTest.DataBind();

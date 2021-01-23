    protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item)
            {
                RadioButtonList RadioButtonList1 = (RadioButtonList)e.Item.FindControl("RadioButtonList1");
                //Get questionID here
                int QuestionID = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "QuestionID"));
                //pass Question ID to your DB and get all available options for the question
                //Bind the RadiobUttonList here
            }
        }

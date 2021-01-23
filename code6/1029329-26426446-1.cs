    //this should be declared and initialized at the Page level so it is available across all runs of the ItemDataBound
    var userColorCache = new Dictionary<string, string>();
    
    DataRowView nRow = null;
    ActiveDirectory AD = new ActiveDirectory();
    GeneralFunctions G = new GeneralFunctions();
    ArrayList Colours = G.getColours();
    Random rnd = new Random();
    
    switch (e.Item.ItemType)
    {
        case ListItemType.Item:
        case ListItemType.AlternatingItem:
            nRow = (DataRowView)e.Item.DataItem;
            var personInitials = AD.getInitialsFromAD(nRow["ThreadPerson"].ToString());
            string userColor = null;
            if (userColorCache.ContainsKey(personInitials)) {
              userColor = userColorCache[personInitials];
            } else {
              int r = rnd.Next(Colours.Count);
              userColor = (string)Colours[r];
              userColorCache.Add(personInitials, userColor)
            }
    
        
            ((Label)e.Item.FindControl("lblInitials")).Text = personInitials;
            ((Label)e.Item.FindControl("lblDate")).Text = nRow["ThreadDate"].ToString();
            ((Label)e.Item.FindControl("lblName")).Text = AD.getFullNameFromSID(nRow["ThreadPerson"].ToString());
            ((Label)e.Item.FindControl("lblText")).Text = nRow["ThreadText"].ToString();
            ((HtmlGenericControl)e.Item.FindControl("divColour")).Attributes.Add("style", "background-color: " + userColor);
            break;
    }

    protected void dlPerson_OnItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            //Find the controls in the Item Template
            Panel pnlPersonEdit = e.Item.FindControlRecursive("pnlPersonEdit") as Panel;
            CollapsiblePanelExtender cpPersonEdit =
                e.Item.FindControlRecursive("cpPersonEdit") as CollapsiblePanelExtender;
            //This panel was a div previously "divEditPerson" I have changed it to panel
            Panel pnlEditPersonHead = e.Item.FindControlRecursive("pnlEditPersonHead") as Panel;
            //Some object from db
            PersonObject personObject = e.Item.DataItem as PersonObject;
       
            //Set Id of the collapsed/expanded panel from unique key
            pnlEditPersonHead.ID += personObject.CrmddressId.ToString();
            //Set Id of the target panel from unique key
            pnlPersonEdit.ID += personObject.CrmddressId.ToString();
            
            //simillarly set Id of the collapsible panel extender
            cpPersonEdit.ID += personObject.CrmddressId.ToString();
            //Now set the TargetControlID, CollapseControlID and ExpandControlID 
            cpPersonEdit.TargetControlID = pnlPersonEdit.ID;
            cpPersonEdit.CollapseControlID = pnlEditPersonHead.ID;
            cpPersonEdit.ExpandControlID = pnlEditPersonHead.ID;
          }
    }

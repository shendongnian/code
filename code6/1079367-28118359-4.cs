     protected void RadGrid1_ItemCreated(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridEditableItem && e.Item.IsInEditMode)
        {
            GridEditFormItem editedItem = e.Item as GridEditFormItem;
 
            TextBoxSetting inputSettings = (DateInputSetting)RadInputManager1.GetSettingByBehaviorID("TextBoxBehavior1");
            RadTextBox tbName = editedItem.FindControl("tbName") as RadTextBox;
            RadTextBox tbDescription = editedItem.FindControl("tbDescription") as RadTextBox; 
            inputSettings.TargetControls.Add(new TargetInput(tbName.UniqueID, true));
            inputSettings.TargetControls.Add(new TargetInput(tbDescription.UniqueID, true));            
        }
    }

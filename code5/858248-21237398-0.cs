    IDictionary<ComboBox, DataRow> _prevSelection;
    //Please don't mind if syntax is wrong worked too long in web
    comboBox.OnSelectedIndexChanged += fixItems;
    private void fixItems(object sender, EventArgs e)
    {
        var cbo= sender as ComboBox;
        if(cbo==null) return;
        var prev = _prevSelection[cbo];
        
        var row=<GET ROW FROM DATATABLE FOR CURRENT SELECTED VALUE>;
    
        _prevSelection[cbo] = row;
        UpdateOtherCombos(cbo, prev, cbo.SelectedItem.Value);
    }
    private void UpdateOtherCombos(ComboBox cbo, DataRow prev, object toRemove)
    {
        foreach(var gridrow in <YourGrid>.Rows)
        {
            var c = <FIND COMBO IN ROW>;
            if(cbo.Id == c.Id) continue;//combo that triggered this all
            var itemToRemove=null;
            foreach(var item in c.Items)
            {
                if(item.Value == toRemove)
                {
                    itemToRemove = item;
                    break;
                }
            }
            //or you can get index of item and remove using index
            c.Items.Remove(itemToRemove);
            //Now add the item that was previously selected in this combo (that 
            //triggered this all)
            c.Items.Add(new ComboBoxItem{Value = prev["ValueColumn"], 
                                            Text = prev ["TextColumn"]});
        }
    }

    Configure(lvData);
    lvData.Clear();
    var myProperties = GetMyAllProperties(typeof(MyDto));
    
    myProperties.Foreach( prop => {
      lvData.Columns.Add(prop.Name);
    }
    var firstProp = false;
    ListViewItem item1 = null;
    myProperties.Foreach( prop => {
           if (!firstProp) item1 = new ListViewItem(prop.Name);
           if (!firstProp) item1.SubItems.Add(prop.Name);
      }
      lvData.Items.Add(item);
      lvData.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

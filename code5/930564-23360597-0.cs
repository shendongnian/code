    SortedList list= new SortedList();
    
    foreach (umbraco.cms.businesslogic.Dictionary.DictionaryItem d2 in d1.Children)
    {
        translation = "";
        translation = new umbraco.cms.businesslogic.Dictionary.DictionaryItem(d2.key).Value(lang);
    
        list.Add(translation, d2.key);
    }
    
    //bind to RadioButtonList 
    RadioButtonList1.DataSource = list;
    RadioButtonList1.DataValueField = "Key";
    RadioButtonList1.DataTextField="Value";
    RadioButtonList1.DataBind();
